using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController2 : MonoBehaviour
{
    public Button button;
    public ScaleButton scaleButton;
    public RandomSpriteButtonCoro randomSpriteButton;

    public JumpButton jumpButton;
    public Vector3 _targetScale;
    public Sprite[] sprites;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        scaleButton.targetScale =_targetScale;
        scaleButton.Scale();
        }
        else if(Input.GetKeyDown(KeyCode.Z)){
            randomSpriteButton.sprites = sprites;
            randomSpriteButton.ChangeSprite();
        }
        else if(Input.GetKeyDown(KeyCode.X)){
            jumpButton.Jump();
        }
    }
}
