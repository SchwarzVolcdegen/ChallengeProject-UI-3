using UnityEngine;
using UnityEngine.UI;
public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public Button button;

    public void ChangeSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        Sprite newSprite = sprites[randomIndex];

        button.GetComponent<Image>().sprite = newSprite;
        
        Debug.Log("Change Sprites");
    }
}
