using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneScore : MonoBehaviour
{
    public Text score;

    void Start()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
    }
}
