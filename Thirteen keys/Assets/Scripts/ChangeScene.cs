using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGameScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void RestartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
