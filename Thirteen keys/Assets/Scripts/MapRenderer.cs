using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public Sprite[] key, doorType, keyHole;
    public GameObject[] obstacle, door;
    public static MapRenderer instance;

    private const int startObsX = 18, length = 10;
    private bool isZero;

    //18, 10

    void Start()
    {
        instance = this;
        isZero = true;

        MapRender();
    }

    public void MapRender()
    {
        if(isZero) //0이라면
        {
            isZero = false;
            int obsN = Random.Range(1, 4);

            int[] obsArray = new int[obsN];

            for (int i = 0; i < obsN; i++)
            {
                obsArray[i] = Random.Range(0, 4);
                for (int j = 0; j < i; j++)
                {
                    if (obsArray[j] == obsArray[i])
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < obsN; i++)
            {
                obstacle[obsArray[i]].SetActive(true);
                if (obsArray[i] == 2)
                {
                    obstacle[obsArray[i]].transform.position = new Vector3(startObsX + length * (i + 1), 1, 0);
                }
                else if(obsArray[i] == 3)
                {
                    obstacle[obsArray[i]].transform.position = new Vector3(startObsX + length * (i + 1), -0.5f, 0);
                }
                else
                {
                    obstacle[obsArray[i]].transform.position = new Vector3(startObsX + length * (i + 1), -2, 0);
                }
            }

            //int doorN = Random.Range(0, 3);
            int doorN = Random.Range(1, 4); //임시

            int[] doorArray = new int[doorN];
            int[] doorArray2 = new int[doorN];

            for (int i = 0; i < doorN; i++)
            {
                doorArray[i] = Random.Range(0, 2);
                doorArray2[i] = Random.Range(0, 7);
            }

            for (int i = 0; i < doorN; i++)
            {

                door[i].SetActive(true);
                Door data = door[i].GetComponent<Door>();
                data.keyHole.GetComponent<SpriteRenderer>().sprite = keyHole[doorArray[i]];
                if (data.keyHole.transform.position.y > 0 && doorArray[i] == 0)
                {
                    data.keyHole.transform.Translate(new Vector3(0, -3, 0));
                }
                else if (data.keyHole.transform.position.y < 0 && doorArray[i] == 1)
                {
                    data.keyHole.transform.Translate(new Vector3(0, 3, 0));
                }
                data.key.GetComponent<SpriteRenderer>().sprite = key[doorArray2[i]];
                door[i].GetComponent<SpriteRenderer>().sprite = doorType[doorArray[i]];
                data.keyHole.transform.name = doorArray2[i].ToString();
                door[i].transform.position = new Vector3(startObsX + length * (obsN + i + 1), -1.5f, 0);
                data.doorDetect.tag = "Door";
                data.killObject.tag = "KillPlayer";
                data.keyHole.tag = "Keyhole2";
                if ((doorN - 1) == i)
                {
                    data.keyHole.tag = "Keyhole";
                }
            }
        }
        else
        {
            isZero = true;
            int obsN = Random.Range(1, 4);

            int[] obsArray = new int[obsN];

            for (int i = 0; i < obsN; i++)
            {
                obsArray[i] = Random.Range(0, 4);
                for (int j = 0; j < i; j++)
                {
                    if (obsArray[j] == obsArray[i])
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < obsN; i++)
            {
                obstacle[obsArray[i] + 4].SetActive(true);
                if (obsArray[i] == 2)
                {
                    obstacle[obsArray[i] + 4].transform.position = new Vector3(startObsX + length * (i + 1), 1, 0);
                }
                else if (obsArray[i] == 3)
                {
                    obstacle[obsArray[i] + 4].transform.position = new Vector3(startObsX + length * (i + 1), -0.5f, 0);
                }
                else
                {
                    obstacle[obsArray[i] + 4].transform.position = new Vector3(startObsX + length * (i + 1), -2, 0);
                }
            }

            int doorN = Random.Range(1, 4);

            int[] doorArray = new int[doorN];
            int[] doorArray2 = new int[doorN];

            for (int i = 0; i < doorN; i++)
            {
                doorArray[i] = Random.Range(0, 2);
                doorArray2[i] = Random.Range(0, 7);
            }

            for (int i = 0; i < doorN; i++)
            {

                door[i + 3].SetActive(true);
                Door data = door[i + 3].GetComponent<Door>();
                data.keyHole.GetComponent<SpriteRenderer>().sprite = keyHole[doorArray[i]];
                if (data.keyHole.transform.position.y > 0 && doorArray[i] == 0)
                {
                    data.keyHole.transform.Translate(new Vector3(0, -3, 0));
                }
                else if (data.keyHole.transform.position.y < 0 && doorArray[i] == 1)
                {
                    data.keyHole.transform.Translate(new Vector3(0, 3, 0));
                }
                data.key.GetComponent<SpriteRenderer>().sprite = key[doorArray2[i]];
                door[i + 3].GetComponent<SpriteRenderer>().sprite = doorType[doorArray[i]];
                data.keyHole.transform.name = doorArray2[i].ToString();
                door[i + 3].transform.position = new Vector3(startObsX + length * (obsN + i + 1), -1.5f, 0);
                data.doorDetect.tag = "Door";
                data.killObject.tag = "KillPlayer";
                data.keyHole.tag = "Keyhole2";
                if ((doorN - 1) == i)
                {
                    data.keyHole.tag = "Keyhole";
                }
            }
        }
        
    }
}
