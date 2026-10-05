using UnityEngine;
using UnityEditor;

public static class CopyReelLayout
{
    [MenuItem("Tools/Copy Reel Layout")]
    static void Run()
    {
        Transform broken = Selection.activeTransform;
        Transform good = null;
        foreach (var t in Selection.transforms)
            if (t != broken) good = t;

        if (broken == null || good == null || Selection.transforms.Length != 2)
        {
            Debug.LogError("Select the GOOD reel first, then Ctrl+click the BROKEN reel.");
            return;
        }
        if (good.childCount != broken.childCount)
        {
            Debug.LogError("Reels have different child counts.");
            return;
        }

        for (int i = 0; i < broken.childCount; i++)
        {
            var src = good.GetChild(i) as RectTransform;
            var dst = broken.GetChild(i) as RectTransform;
            if (src == null || dst == null) continue;
            Undo.RecordObject(dst, "Copy reel layout");
            dst.anchorMin = src.anchorMin;
            dst.anchorMax = src.anchorMax;
            dst.pivot = src.pivot;
            dst.sizeDelta = src.sizeDelta;
            dst.anchoredPosition = src.anchoredPosition;
            dst.localScale = src.localScale;
        }
        Debug.Log("Reel layout copied.");
    }
}