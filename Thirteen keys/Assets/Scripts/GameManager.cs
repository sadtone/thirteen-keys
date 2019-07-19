using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int currentTheme;
    public int currentScore;

    public SpriteRenderer background, ground;
    public Sprite[] _background, _ground;

    private void Awake()
    {
        currentTheme = 0;
        currentScore = 0;
    }

    public void SetTheme(int theme)
    {
    }

}
