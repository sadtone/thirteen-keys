using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetect : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            Time.timeScale = 0.2f; //5초에 trigger raius만큼 움직이게 해야해요 아시겠죠
        }
        if (other.CompareTag("OpenedDoor"))
        {
            Time.timeScale = 1;
        }
    }
}
