using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : MonoBehaviour
{
    public Button fadeButton;
    public float duration = 1f;

    public void Fade(){
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine(){
        Image buttonImage = fadeButton.GetComponent<Image>();
        Color originalColor = buttonImage.color;
        float elapsed = 0f;

        while(elapsed < duration){
            float alpha = Mathf.Lerp(originalColor.a,0, elapsed/duration);
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}
