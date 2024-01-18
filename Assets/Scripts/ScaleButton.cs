using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour
{
    public Button button;
    public Vector3 targetScale;
    public float duration = 1f;
    Vector3 originalScale;
    public void Scale()
    {
        StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        originalScale = button.transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            button.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = targetScale;
        StartCoroutine(ResetScaleCoroutine());
    }

    IEnumerator ResetScaleCoroutine(){
        float elapsed = 0f;
        Vector3 currentScale = button.transform.localScale;

        while (elapsed < duration)
        {
            button.transform.localScale = Vector3.Lerp(currentScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = originalScale;
    }
}
