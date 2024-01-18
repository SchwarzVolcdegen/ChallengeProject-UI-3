using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimatedButtonController : MonoBehaviour
{
    public ScaleButton scaleButton;
    public Button scaleButton2;
    public RandomSpriteButtonCoro randomSpriteButton;
    public JumpButton jumpButton;
    public SpinButton spinButton;

    public FadeButton fadeButton;
    public Vector3 _targetScale;
    public Vector3 _targetScale2;
    public Sprite[] sprites;

    public float delay = 0.5f;

    void Start()
    {
        StartCoroutine(RunButtonActionsCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunButtonActionsCoroutine(){
        StartCoroutine(ScalingButton(_targetScale));
        yield return DelayAction();

        StartCoroutine(ScalingButton(_targetScale2));
        yield return DelayAction();

        StartCoroutine(RandomingSpriteButton());
        yield return DelayAction();

        StartCoroutine(JumpingButton());
        yield return DelayAction();

        StartCoroutine(SpinningButton());
        yield return DelayAction();

        StartCoroutine(FadingButton());
        yield return DelayAction();

    }


    IEnumerator ScalingButton(Vector3 targetScale){
        scaleButton.targetScale = targetScale;
        scaleButton.Scale();
        yield return DelayAction();
    }

    IEnumerator RandomingSpriteButton(){
        randomSpriteButton.ChangeSprite();
        yield return DelayAction();
    }

    IEnumerator JumpingButton(){
        jumpButton.Jump();
        yield return DelayAction();
    }

    IEnumerator SpinningButton(){
        spinButton.Spin();
        yield return DelayAction();
    }

    IEnumerator FadingButton(){
        fadeButton.Fade();
        yield return DelayAction();
    }
    IEnumerator DelayAction(){
        yield return new WaitForSeconds(1f);
    }
}
