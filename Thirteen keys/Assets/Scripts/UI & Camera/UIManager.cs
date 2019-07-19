using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject keyBagUI, pauseUI;
    public Transform ground1, ground2;
    public Transform[] background;
    //-95.9 , 15

    void Start()
    {

    }

    void Update()
    {
        ground1.Translate(Vector3.left * GameManager.moveSpeed * Time.deltaTime);
        ground2.Translate(Vector3.left * GameManager.moveSpeed * Time.deltaTime);

        if (ground1.position.x <= -45)
            ground1.position = new Vector3(15, -5, 0);
        if (ground2.position.x <= -45)
            ground2.position = new Vector3(15, -5, 0);

        for (int i = 0; i < 3; i++)
        {
            background[i].transform.Translate(Vector3.left * GameManager.moveSpeed * Time.deltaTime);

            if (background[i].transform.position.x <= -36)
                background[i].transform.position = new Vector3(18, 0, 1);
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
        SceneManager.LoadScene("MainScene");
    }
}
