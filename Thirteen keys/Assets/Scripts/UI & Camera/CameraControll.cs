using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector3 beforePos;
    private bool isDoorDetected;

    void Start()
    {
        beforePos = transform.position;
    }

    void Update()
    {
        if (isDoorDetected)
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        else
        {
            transform.position = beforePos;
        }
    }

    public void DoorDetected()
    {
        isDoorDetected = true;
    }

    public void BackToOrigin()
    {
        isDoorDetected = false;
    }

    private IEnumerator Shake(float power, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * power + beforePos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = beforePos;

    }
}
