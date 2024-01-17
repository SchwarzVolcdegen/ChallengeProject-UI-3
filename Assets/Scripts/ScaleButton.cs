using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour
{
    public Button button;
    public Vector3 targetScale;
    public float duration = 1f;

    public void Scale()
    {
        StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        Vector3 originalScale = button.transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            button.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Scaled...");
        button.transform.localScale = targetScale;
    }

}
