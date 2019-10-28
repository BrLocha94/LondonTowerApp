using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int current_level = 0;

    bool is_holding = false;

	void Start ()
    {
		
	}
	
    public bool getIsHolding()
    {
        return is_holding;
    }

}
