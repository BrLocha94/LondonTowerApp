using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    private int value;

    void Update()
    {
        //Debug.Log("Ring " + value + " " + gameObject.transform.position); 
    }

    public int getValue()
    {
        return value;
    }
}
