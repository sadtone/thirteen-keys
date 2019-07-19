using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCtrl : MonoBehaviour
{

    public float moveSpeed = 5;
    
    private void Update()
    {

        gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

    }
}
