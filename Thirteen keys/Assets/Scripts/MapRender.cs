using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{

    public GameObject[] pattern;
    public float obsRange;

    public void SetPattern()
    {
        for(int i = 0; i < pattern.Length; i++)
        {
            pattern[i].SetActive(false);
        }

        int obsNum = Random.Range(0, 4);
        int doorNum = DoorRandom();

        int[] obsArr = new int[obsNum];

        for(int i = 0; i < obsNum; i++)
        {
            obsArr[i] = Random.Range(0, 5);
            for(int j = 0; j < i; j++)
            {
                if(obsArr[i] == obsArr[j])
                {
                    i--;
                    break;
                }
            }
        }

        for(int i = 0; i < obsNum; i++)
        {
            pattern[obsArr[i]].SetActive(true);
            pattern[obsArr[i]].transform.position = new Vector3(12 + i * obsRange, 0, 0);
        }


    }

    private int DoorRandom()
    {
        int[] ran = { 1, 1, 2, 2, 2, 3, 3 };
        return ran[Random.Range(0, 7)];
    }

}
