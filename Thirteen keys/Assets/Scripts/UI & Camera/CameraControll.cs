﻿using System.Collections;
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
            transform.Translate(Vector3.left * GameManager.moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate((beforePos - transform.position) * Time.deltaTime);
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

    public void ShakeStart(float power, float duration)
    {
        StartCoroutine(Shake(power, duration));
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
