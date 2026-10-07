using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetScrollOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        ResetAll();
        StartCoroutine(ResetNextFrame());
    }

    private IEnumerator ResetNextFrame()
    {
        yield return null;
        ResetAll();
    }

    private void ResetAll()
    {
        Canvas.ForceUpdateCanvases();
        foreach (var sr in GetComponentsInChildren<ScrollRect>(true))
        {
            sr.StopMovement();
            if (sr.vertical) sr.verticalNormalizedPosition = 1f;
            if (sr.horizontal) sr.horizontalNormalizedPosition = 0f;
        }
    }
}