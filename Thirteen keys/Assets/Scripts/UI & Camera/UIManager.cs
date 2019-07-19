using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject keyBagUI, pauseUI;
    public Transform ground1, ground2, backGround, door;
    //-95.9 , 15

    void Start()
    {
    }

    void Update()
    {
        door.Translate(Vector3.left * 5f * Time.deltaTime);
        ground1.Translate(Vector3.left * 5f * Time.deltaTime);
        ground2.Translate(Vector3.left * 5f * Time.deltaTime);

        if (ground1.position.x <= -45)
            ground1.position = new Vector3(15, -5, 0);
        if (ground2.position.x <= -45)
            ground2.position = new Vector3(15, -5, 0);

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
