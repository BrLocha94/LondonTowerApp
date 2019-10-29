using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    private int value;

    GameObject current_parent;

    public int getValue()
    {
        return value;
    }

    public void setCurrentParent(GameObject param)
    {
        current_parent = param;
    }

    public GameObject getCurrentParent()
    {
        return current_parent;
    }
}
