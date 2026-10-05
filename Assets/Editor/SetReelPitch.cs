using UnityEngine;
using UnityEditor;

public static class SetReelPitch
{
    [MenuItem("Tools/Set Reel Pitch")]
    static void Run()
    {
        float pitch = 205f;
        float caseStopY = 160f; // must match SlotView's case1StopY
        foreach (var reel in Selection.transforms)
        {
            int count = reel.childCount;
            for (int i = 0; i < count; i++)
            {
                var icon = reel.GetChild(i) as RectTransform;
                if (icon == null) continue;
                Undo.RecordObject(icon, "Set Reel Pitch");
                Vector2 pos = icon.anchoredPosition;
                pos.y = -caseStopY + (7 - i) * pitch;
                icon.anchoredPosition = pos;
            }
        }
        Debug.Log("Reel pitch updated.");
    }
}