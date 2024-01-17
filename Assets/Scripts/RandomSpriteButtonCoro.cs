using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpriteButtonCoro : MonoBehaviour
{
    public Button changeSpriteButton;
    public Sprite[] sprites;
    public float duration = 1f;

    public void ChangeSprite()
    {
        StartCoroutine(ChangeSpriteCoroutine());
    }
    
    IEnumerator ChangeSpriteCoroutine()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        Sprite newSprite = sprites[randomIndex];

        float elapsed = 0f;

        while (elapsed < duration)
        {
            changeSpriteButton.GetComponent<Image>().sprite = newSprite;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Change Sprites");
    }
}
