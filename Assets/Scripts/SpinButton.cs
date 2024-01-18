using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    public Button spinButton;
    public float spinSpeed = 10f;

    public float duration = 1f;

    public void Spin(){
        StartCoroutine(SpinCoroutine());
    }

    IEnumerator SpinCoroutine(){
        Quaternion originalRotation = spinButton.transform.rotation;
        float elapsed = 0f;

        while(elapsed < duration){
            float deltaAngle = spinSpeed * elapsed;
            spinButton.transform.Rotate(Vector3.forward * deltaAngle);

            elapsed += Time.deltaTime;
            yield return null;
        }

        spinButton.transform.rotation = originalRotation;
    }
}
