using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField]
    public Button playButton;
    [SerializeField]
    public Button pauseButton;
    [SerializeField]
    public Button resetButton;
    [SerializeField]
    public Button rescaleButton;
    [SerializeField]
    public Button randomSpriteButton;
    [SerializeField]
    public Button jumpButton;
    [SerializeField]
    public Button spinButton;
    [SerializeField]
    public Button fadeButton;
    [SerializeField]
    public Button animatedButton;
    [SerializeField]
    public GameObject animationControlUI;
    public Vector3 targetScale;
    public Sprite[] sprites;
    private bool playAnimationFlag = false;
    private bool pauseAnimationFlag = false;
    private bool resetButtonFlag = true;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private Sprite originalSprite;


    private List<UnityAction> buttonActionListeners = new List<UnityAction>();

    void OnEnable(){
        originalRotation = animatedButton.transform.rotation;
        originalScale = animatedButton.transform.localScale;
        originalSprite = animatedButton.GetComponent<Image>().sprite;
    }
    void Start()
    {
        AddListenerToButton(playButton);
        AddListenerToButton(pauseButton);
        AddListenerToButton(resetButton);
        AddListenerToButton(rescaleButton);
        AddListenerToButton(randomSpriteButton);
        AddListenerToButton(jumpButton);
        AddListenerToButton(spinButton);
        AddListenerToButton(fadeButton);
        AddListenerToButton(animatedButton);
    }

    // Update is called once per frame
    void Update()
    {
        resetButton.interactable = resetButtonFlag;
    }

    void OnDisable()
    {
        RemoveAllListenerOfButton(playButton);
        RemoveAllListenerOfButton(pauseButton);
        RemoveAllListenerOfButton(resetButton);
        RemoveAllListenerOfButton(rescaleButton);
        RemoveAllListenerOfButton(randomSpriteButton);
        RemoveAllListenerOfButton(jumpButton);
        RemoveAllListenerOfButton(spinButton);
        RemoveAllListenerOfButton(fadeButton);
        RemoveAllListenerOfButton(animatedButton);
    }

    private void ButtonClicked(Button button)
    {
        Debug.Log(button.name + " is Clicked!");

        if (button.gameObject.tag == "Action Control Button")
        {
            ActiveUI(animationControlUI);
            resetButtonFlag = true;
            ResetButtonState();
            
            switch (button.name)
            {
                case "Scale Button":
                    StartCoroutine(ScaleCoroutine(animatedButton, targetScale));
                    break;
                case "Random Sprite Button":
                    StartCoroutine(ChangeSpriteCoroutine(animatedButton, sprites));
                    break;
                case "Jump Button":

                    break;
                case "Spin Button":

                    break;
                case "Fade Button":

                    break;
            }
        }
        else if (button.gameObject.tag == "Animation Control Button")
        {
            switch (button.name)
            {
                case "Play Button":

                    break;
                case "Pause/Resume Button":

                    break;
                case "Reset Button":
                    ResetButtonState();
                    resetButtonFlag = false;
                    
                    break;
            }
        }
        else if (button.gameObject.tag == "Untagged")
        {
            DisableUI(animationControlUI);
        }
    }

    private void ActiveUI(GameObject UI)
    {
        UI.SetActive(true);
        Debug.Log(UI.name + " is active!");
    }

    private void DisableUI(GameObject UI)
    {
        UI.SetActive(false);
        Debug.Log(UI.name + " is disabled!");
    }

    private void AddListenerToButton(Button button)
    {
        UnityAction listener = () => ButtonClicked(button);
        button.onClick.AddListener(listener);
        buttonActionListeners.Add(listener);
    }

    private void RemoveAllListenerOfButton(Button button)
    {
        foreach (var listener in buttonActionListeners)
        {
            button.onClick.RemoveListener(listener);
        }
        buttonActionListeners.Clear();
    }

    IEnumerator RunAnimationCoroutine()
    {
        yield return new WaitUntil(() => playAnimationFlag == true);
    }

    IEnumerator PauseAnimationCoroutine()
    {
        yield return new WaitUntil(() => pauseAnimationFlag == true);
    }

    public void ResetButtonState()
    {
        animatedButton.transform.rotation = originalRotation;
        animatedButton.transform.localScale = originalScale;
        animatedButton.GetComponent<Image>().sprite = originalSprite;
    }

    IEnumerator ScaleCoroutine(Button button, Vector3 targetScale)
    {
        Vector3 originalScale = button.transform.localScale;
        float elapsed = 0f;
        float duration = 1f;

        while (elapsed < duration)
        {
            button.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = targetScale;
        StartCoroutine(ResetScaleCoroutine(button, originalScale));
    }

    IEnumerator ResetScaleCoroutine(Button button, Vector3 originalScale)
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector3 currentScale = button.transform.localScale;

        while (elapsed < duration)
        {
            button.transform.localScale = Vector3.Lerp(currentScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = originalScale;
    }

    IEnumerator ChangeSpriteCoroutine(Button button, Sprite[] sprites)
    {
        int randomIndex = Random.Range(0, sprites.Length);
        Sprite newSprite = sprites[randomIndex];

        float elapsed = 0f;
        float duration = 1f;

        while (elapsed < duration)
        {
            button.GetComponent<Image>().sprite = newSprite;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
