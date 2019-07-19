using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{

    public GameObject[] pattern;
    public float patternWidth;

    private int[] currentPattern;

    private void Awake()
    {
        currentPattern = new int[2];
    }

    public void SetPattern()
    {
        for(int i = 0; i < 11; i++)
        {
            pattern[i].SetActive(false);
        }

        currentPattern[0] = Random.Range(0, 11);
        currentPattern[1] = Random.Range(0, 11);

        pattern[currentPattern[0]].SetActive(true);
        pattern[currentPattern[1]].SetActive(true);

        pattern[currentPattern[0]].transform.position = new Vector3(10, 0, 0);
        pattern[currentPattern[1]].transform.position = new Vector3(10 + patternWidth, 0, 0);
    }

}
