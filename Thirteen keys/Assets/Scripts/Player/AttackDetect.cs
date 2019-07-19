using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackDetect : MonoBehaviour
{
    private int cnt;
    private bool isAttacked;
    private PlayerControll pC;

    public GameObject bloodEffect;
    public CameraControll cameraMain;
    public GameObject body;
    public AudioClip doorOpenSound;
    

    void Start()
    {
        cnt = 0;
        pC = GetComponentInParent<PlayerControll>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (!isAttacked)
            {
                StartCoroutine(Attacked());
                cnt++;
            }
            if (cnt >= 2)
            {
                //게임 오버
                PlayerPrefs.SetInt("score", GameManager.currentScore);
                SceneManager.LoadScene("EndingScene");
            }
            
                

        }
        if (other.CompareTag("Keyhole"))
        {
            if(pC.keyCodeNow.ToString() == other.name)
            {
                cameraMain.ShakeStart(0.7f, 0.2f);
                other.transform.parent.gameObject.GetComponent<Door>().doorDetect.tag = "OpenedDoor";
                other.transform.parent.gameObject.GetComponent<Door>().killObject.tag = "Untagged";
                GameManager.moveSpeed += 0.3f;
                GameManager.currentScore += 1000;
                GameManager.clearDoor++;
                MapRenderer.instance.MapRender();
                SoundManager.instance.PlaySound(doorOpenSound);
            }
        }
        if (other.CompareTag("Keyhole2"))
        {
            if (pC.keyCodeNow.ToString() == other.name)
            {
                cameraMain.ShakeStart(0.7f, 0.2f);
                other.transform.parent.gameObject.GetComponent<Door>().doorDetect.tag = "OpenedDoor";
                other.transform.parent.gameObject.GetComponent<Door>().killObject.tag = "Untagged";
                GameManager.currentScore += 1000;
                SoundManager.instance.PlaySound(doorOpenSound);
            }
        }
        if (other.CompareTag("KillPlayer"))
        {
            PlayerPrefs.SetInt("score", GameManager.currentScore);
            SceneManager.LoadScene("EndingScene");
        }
    }

    private IEnumerator Attacked()
    {
        cameraMain.ShakeStart(0.5f, 0.2f);
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
