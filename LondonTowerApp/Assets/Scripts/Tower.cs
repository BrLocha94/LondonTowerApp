using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameController controller;

    [SerializeField]
    private Transform[] positions;

    int capacity;
    List<Ring> current_rings = new List<Ring>();

	void Start ()
    {
        if (controller == null)
        {
            Debug.Log("Controller is not declared");
            GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (controllerObject != null)
                controller = controllerObject.GetComponent<GameController>();
            else
                Debug.Log("Cant find controller");
        }

        capacity = positions.Length;
	}
	
    public void onTowerClick(AudioClip param)
    {
        Debug.Log("ENTROU");

        if (controller.getIsHolding())
        {
            if (current_rings.Count < capacity)
            {
                //move from hand to ring
                //add to current_rings
                //play move sfx sound
                SoundController.instance().playSfx(param);

                //modify is holding on controller
            }
            else
            {
                //Cant move treatment
                SoundController.instance().playError();
            }
        }
        else
        {
            if(current_rings.Count > 0)
            {
                //move from tower to hand
                //remove from current_rings
                //play move sfx sound
                SoundController.instance().playSfx(param);

                //modify is holding on controller
            }
            else
            {
                //cant move treatment
                SoundController.instance().playError();
            }
        }
    }

}
