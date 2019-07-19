using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCtrl : MonoBehaviour
{
    
    private void Update()
    {

        gameObject.transform.Translate(Vector3.left * GameManager.moveSpeed * Time.deltaTime);

    }
}
