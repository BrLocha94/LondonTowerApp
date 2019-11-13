using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPrefs : MonoBehaviour
{

	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
	
	
}
