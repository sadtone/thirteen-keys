using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject keyBagUI, pauseUI;
    public Transform ground, backGround;

    private float groundX, backGroundX;

    void Start()
    {
        groundX = 20;
    }

    void Update()
    {
        if(ground.position.x > -groundX)
        {
            ground.Translate(new Vector3(-10f * Time.deltaTime, 0, 0));
        }
        else
        {
            ground.position = new Vector3(groundX, -5, 0);
        }
    }

    public void OnPauseUI()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        //메인 화면으로
    }
}
