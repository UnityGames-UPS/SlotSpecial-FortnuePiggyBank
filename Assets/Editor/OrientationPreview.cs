#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// Edit-mode preview of what OCController.HandleOrientationChange applies at runtime.
// Put this file in Assets/Editor/. Menu: Tools > Preview Portrait / Preview Landscape.
// Everything is Undo-able (Ctrl+Z).
public static class OrientationPreview
{
    [MenuItem("Tools/Preview Portrait")]
    private static void Portrait() { Apply(true); }

    [MenuItem("Tools/Preview Landscape")]
    private static void Landscape() { Apply(false); }

    private static void Apply(bool portrait)
    {
        if (Application.isPlaying)
        {
            Debug.LogWarning("[OrientationPreview] Edit mode only. In Play mode the real OCController already handles this.");
            return;
        }

        var oc = Object.FindFirstObjectByType<OCController>(FindObjectsInactive.Include);
        if (oc == null)
        {
            Debug.LogError("[OrientationPreview] No OCController found in the open scene.");
            return;
        }

        var so = new SerializedObject(oc);
        Undo.IncrementCurrentGroup();
        Undo.SetCurrentGroupName(portrait ? "Preview Portrait" : "Preview Landscape");
        int group = Undo.GetCurrentGroup();

        // Panels and backgrounds
        SetActive(Ref<GameObject>(so, "landscapePanelObject"), !portrait);
        SetActive(Ref<GameObject>(so, "portraitPanelObject"), portrait);
        SetActive(Ref<GameObject>(so, "landscapeBackground"), !portrait);
        SetActive(Ref<GameObject>(so, "portraitBackground"), portrait);

        // Landscape-only objects (e.g. BGSparkle)
        var landscapeOnly = so.FindProperty("landscapeOnlyObjects");
        if (landscapeOnly != null)
        {
            for (int i = 0; i < landscapeOnly.arraySize; i++)
            {
                SetActive(landscapeOnly.GetArrayElementAtIndex(i).objectReferenceValue as GameObject, !portrait);
            }
        }

        // Canvas scaler
        var orientation = Ref<OrientationChange>(so, "orientationChange");
        if (orientation == null) orientation = Object.FindFirstObjectByType<OrientationChange>(FindObjectsInactive.Include);
        var scaler = Ref<CanvasScaler>(so, "canvasScaler");
        if (scaler == null && orientation != null) scaler = orientation.GetComponent<CanvasScaler>();
        if (scaler != null)
        {
            Undo.RecordObject(scaler, "Preview Orientation");
            Vector2 refRes = portrait ? Vec2(so, "portraitReferenceResolution") : Vec2(so, "landscapeReferenceResolution");
            scaler.referenceResolution = refRes;
            Vector2 gv = Handles.GetMainGameViewSize();
            float scaleW = gv.x / refRes.x;
            float scaleH = gv.y / refRes.y;
            scaler.matchWidthOrHeight = (scaleW <= scaleH) ? 0f : 1f;
        }

        // Resized objects
        Vector2 size = portrait ? Vec2(so, "portraitResizedObjectSize") : Vec2(so, "landscapeResizedObjectSize");
        SetSizes(so, "resizedObjects", size);
        Vector2 sqSize = portrait ? Vec2(so, "portraitSquareResizedObjectSize") : Vec2(so, "landscapeSquareResizedObjectSize");
        SetSizes(so, "squareResizedObjects", sqSize);

        // Slot object (SlotBG)
        var slot = Ref<Transform>(so, "slotObject");
        if (slot != null)
        {
            Undo.RecordObject(slot, "Preview Orientation");
            slot.localScale = portrait ? Vec3(so, "portraitSlotScale") : Vec3(so, "landscapeSlotScale");
            slot.localPosition = portrait ? Vec3(so, "portraitSlotPosition") : Vec3(so, "landscapeSlotPosition");
        }

        // Slot frame
        var frame = Ref<Transform>(so, "frameObject");
        if (frame != null)
        {
            Undo.RecordObject(frame, "Preview Orientation");
            frame.localScale = portrait ? Vec3(so, "portraitFrameScale") : Vec3(so, "landscapeFrameScale");
            frame.localPosition = portrait ? Vec3(so, "portraitFramePosition") : Vec3(so, "landscapeFramePosition");
        }

        // Logo
        var logo = Ref<RectTransform>(so, "logoObject");
        if (logo != null)
        {
            Undo.RecordObject(logo, "Preview Orientation");
            logo.localScale = portrait ? Vec3(so, "portraitLogoScale") : Vec3(so, "landscapeLogoScale");
            logo.anchoredPosition = portrait ? Vec2(so, "portraitLogoPosition") : Vec2(so, "landscapeLogoPosition");
        }

        // Info page and guide scroll heights
        float h = portrait ? 1920f : 1080f;
        SetHeight(Ref<RectTransform>(so, "infoPageScrollObject"), h);
        SetHeight(Ref<RectTransform>(so, "guideScrollObject"), h);

        Undo.CollapseUndoOperations(group);
        SceneView.RepaintAll();
        Debug.Log("[OrientationPreview] Applied " + (portrait ? "PORTRAIT" : "LANDSCAPE") +
                  ". Set the Game view to " + (portrait ? "1080x1920" : "1920x1080") +
                  ". Switch back to LANDSCAPE before saving the scene.");
    }

    private static T Ref<T>(SerializedObject so, string name) where T : Object
    {
        var p = so.FindProperty(name);
        return p != null ? p.objectReferenceValue as T : null;
    }

    private static Vector2 Vec2(SerializedObject so, string name) { return so.FindProperty(name).vector2Value; }
    private static Vector3 Vec3(SerializedObject so, string name) { return so.FindProperty(name).vector3Value; }

    private static void SetActive(GameObject go, bool active)
    {
        if (go == null) return;
        Undo.RecordObject(go, "Preview Orientation");
        go.SetActive(active);
    }

    private static void SetSizes(SerializedObject so, string listName, Vector2 size)
    {
        var list = so.FindProperty(listName);
        if (list == null) return;
        for (int i = 0; i < list.arraySize; i++)
        {
            var rt = list.GetArrayElementAtIndex(i).objectReferenceValue as RectTransform;
            if (rt == null) continue;
            Undo.RecordObject(rt, "Preview Orientation");
            rt.sizeDelta = size;
        }
    }

    private static void SetHeight(RectTransform rt, float height)
    {
        if (rt == null) return;
        Undo.RecordObject(rt, "Preview Orientation");
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
    }
}
#endif