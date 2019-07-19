using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void EndGameScene()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public void RestartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
