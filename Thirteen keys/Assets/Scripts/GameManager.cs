using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int currentTheme;
    public static int currentScore;
    public static float moveSpeed;
    public static int clearDoor;

    public Text score;

    private void Awake()
    {
        currentTheme = 0;
        currentScore = 0;
        moveSpeed = 10;
        clearDoor = 0;
    }

    private void Update()
    {
        currentScore += 1;
        score.text = "점수 : " + currentScore;
    }

    public static void UpgradeTheme()
    {
        if(currentTheme == 0)
        {
            currentTheme = 1;
        }
        else if (currentTheme == 1)
        {
            currentTheme = 2;
        }
        else if(currentTheme == 2)
        {
            currentTheme = 0;
        }
    }

}
