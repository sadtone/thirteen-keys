using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{

    public GameObject[] pattern;
    public GameObject[] door;
    public float obsRange;

    void Start()    
    {
        SetPattern();
    }

    public void SetPattern()
    {
        for(int i = 0; i < 4; i++)
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

        float lastObsX = 12;
        for(int i = 0; i < obsNum; i++)
        {
            pattern[obsArr[i]].SetActive(true);
            lastObsX = 12 + i * obsRange;
            pattern[obsArr[i]].transform.position = new Vector3(lastObsX, 0, 0);
        }

        for (int i = 0; i < door.Length; i++)
        {
            door[i].SetActive(false);
        }

        int[] doorArr = new int[doorNum];

        for (int i = 0; i < doorNum; i++)
        {
            //doorArr[i] = Random.Range(0, 14);
            doorArr[i] = Random.Range(0, 1);
            for (int j = 0; j < i; j++)
            {
                if (doorArr[i] == doorArr[j])
                {
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < doorNum; i++)
        {
            door[doorArr[i]].SetActive(true);
            door[doorArr[i]].transform.position = new Vector3(lastObsX + (i + 1) * obsRange, 0, 0);
        }

    }

    private int DoorRandom()
    {
        int[] ran = { 1, 1, 2, 2, 2, 3, 3 };
        return ran[Random.Range(0, 7)];
    }

}
