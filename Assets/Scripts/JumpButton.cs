using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public Button jumpButton;
    public float duration = 1f;

    private Vector3 highestJumpLocation;


    public void Jump()
    {

        StartCoroutine(JumpCoroutine());
        Debug.Log("Jump");
    }

    IEnumerator JumpCoroutine()
    {
        Vector3 originalPosition = jumpButton.transform.position;
        highestJumpLocation = originalPosition;
        highestJumpLocation.y = originalPosition.y + 200;
        float elapsed = 0;

        while (elapsed < duration)
        {
            if (elapsed < duration)
            {
                jumpButton.transform.position = Vector3.Lerp(originalPosition, highestJumpLocation, elapsed / duration);

            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        jumpButton.transform.position = highestJumpLocation;

        StartCoroutine(FallBackDownCoroutine(originalPosition));
    }

    IEnumerator FallBackDownCoroutine(Vector3 originalPosition)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            jumpButton.transform.position = Vector3.Lerp(highestJumpLocation, originalPosition, elapsed / duration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        jumpButton.transform.position = originalPosition;
    }
}
