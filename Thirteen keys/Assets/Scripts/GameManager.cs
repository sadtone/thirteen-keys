using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int currentTheme;
    public static int currentScore;
    public static float moveSpeed;
    public static int clearDoor;

    private void Awake()
    {
        currentTheme = 0;
        currentScore = 0;
        moveSpeed = 10;
        clearDoor = 0;
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
