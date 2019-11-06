using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public GameController game_controller;

    public GameObject ring_1;
    public GameObject ring_2;
    public GameObject ring_3;

    public Transform pos_1_0;
    public Transform pos_2_0;
    public Transform pos_2_1;
    public Transform pos_3_0;
    public Transform pos_3_1;
    public Transform pos_3_2;

    void Start ()
    {
		if(gameObject == null)
        {
            Debug.Log("GameController is not defined");
            GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (controllerObject != null)
            {
                game_controller = controllerObject.GetComponent<GameController>();
                //updateHud();
            }
            else
                Debug.Log("GameController not found");
        }
        
    }
	
	public void updateHud()
    {
        Level level = game_controller.getCurrentLevel();
        Ring[] tower_rings;

        for(int i = 0; i < 3; i++)
        {
            tower_rings = level.getRingsTower(i);
            for(int j = 0; j < tower_rings.Length; j++)
            {
                if (i == 0)
                {
                    if (tower_rings[j].getValue() == 1)
                        ring_1.transform.position = pos_1_0.transform.position;
                    else if (tower_rings[j].getValue() == 2)
                        ring_2.transform.position = pos_1_0.transform.position;
                    else if (tower_rings[j].getValue() == 3)
                        ring_3.transform.position = pos_1_0.transform.position;
                }
                else if (i == 1)
                {
                    if (tower_rings[j].getValue() == 1)
                    {
                        if (j == 0)
                            ring_1.transform.position = pos_2_0.transform.position;
                        else if (j == 1)
                            ring_1.transform.position = pos_2_1.transform.position;
                    }
                    else if (tower_rings[j].getValue() == 2)
                    {
                        if (j == 0)
                            ring_2.transform.position = pos_2_0.transform.position;
                        else if (j == 1)
                            ring_2.transform.position = pos_2_1.transform.position;
                    }
                    else if (tower_rings[j].getValue() == 3)
                    {
                        if (j == 0)
                            ring_3.transform.position = pos_2_0.transform.position;
                        else if (j == 1)
                            ring_3.transform.position = pos_2_1.transform.position;
                    }
                }
                else if (i == 2)
                {
                    if (tower_rings[j].getValue() == 1)
                    {
                        if (j == 0)
                            ring_1.transform.position = pos_3_0.transform.position;
                        else if (j == 1)
                            ring_1.transform.position = pos_3_1.transform.position;
                        else if (j == 2)
                            ring_1.transform.position = pos_3_2.transform.position;
                    }
                    else if (tower_rings[j].getValue() == 2)
                    {
                        if (j == 0)
                            ring_2.transform.position = pos_3_0.transform.position;
                        else if (j == 1)
                            ring_2.transform.position = pos_3_1.transform.position;
                        else if (j == 2)
                            ring_2.transform.position = pos_3_2.transform.position;
                    }
                    else if (tower_rings[j].getValue() == 3)
                    {
                        if (j == 0)
                            ring_3.transform.position = pos_3_0.transform.position;
                        else if (j == 1)
                            ring_3.transform.position = pos_3_1.transform.position;
                        else if (j == 2)
                            ring_3.transform.position = pos_3_2.transform.position;
                    }
                }
            }
        }
    }
}
