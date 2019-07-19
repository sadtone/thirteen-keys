using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    private int cnt;
    private bool isAttacked;

    public GameObject bloodEffect;
    public CameraControll cameraMain;
    public GameObject body;

    void Start()
    {
        cnt = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            cnt++;
            if (cnt > 2)
            {
                //게임 오버
                Debug.Log("GameOver");
            }
            if(!isAttacked)
                StartCoroutine(Attacked());

        }
    }

    private IEnumerator Attacked()
    {
        cameraMain.ShakeStart(1, 0.2f);
        bloodEffect.SetActive(true);
        StartCoroutine(FadeInOut(bloodEffect, 100));
        StartCoroutine(FadeInOut(body, 50));


        yield break;
    }

    private IEnumerator FadeInOut(GameObject target, int amount)
    {
        isAttacked = true;
        SpriteRenderer tar = target.GetComponent<SpriteRenderer>();

        Color color = tar.color;
        color.a = (100 - amount) * 0.01f;

        tar.color = color;

        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < amount; j++)
            {
                if (i % 2 == 0)
                    color.a = (100 - amount) * 0.01f + j * 0.01f;
                else
                    color.a = 1 - j * 0.01f;
                
                tar.color = color;
                yield return new WaitForSeconds(0.002f);
            }
        }
        color.a = 1;

        if (amount == 100)
        {
            if(!isAttacked)
                target.SetActive(false);
        }
        else
        {
            tar.color = color;
            isAttacked = false;
        }
            
        
        yield break;
    }
}
