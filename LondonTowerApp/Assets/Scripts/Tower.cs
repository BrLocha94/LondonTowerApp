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
        capacity = positions.Length;

        if (controller == null)
        {
            Debug.Log("Controller is not declared");
            GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (controllerObject != null)
                controller = controllerObject.GetComponent<GameController>();
            else
                Debug.Log("Cant find controller");
        }
	}
	
    public void onTowerClick(AudioClip param)
    {
        if (!controller.getChecking())
        {
            if (controller.getIsHolding())
            {
                if (current_rings.Count < capacity)
                {
                    //move from hand to ring
                    downCurrentRing();
                    //play move sfx sound
                    SoundController.instance().playSfx(param);
                }
                else
                {
                    //Cant move treatment
                    SoundController.instance().playError();
                }
            }
            else
            {
                if (current_rings.Count > 0)
                {
                    //move from tower to hand
                    upLastRing();
                    //play move sfx sound
                    SoundController.instance().playSfx(param);
                }
                else
                {
                    //cant move treatment
                    SoundController.instance().playError();
                }
            }
        }
        else
        {
            Debug.Log("Waiting to return");
        }
    }

    public void upLastRing()
    {
        if(current_rings.Count > 0)
        {
            Ring lastRing = current_rings[current_rings.Count - 1];
            controller.setCurrentRing(lastRing);
            current_rings.RemoveAt(current_rings.Count - 1);
        }
    }

    public void downCurrentRing()
    {
        if (current_rings.Count < capacity)
        {
            Ring lastRing = controller.getCurrentRing();
            controller.setCurrentRing(null);
            current_rings.Add(lastRing);
        }
    }

    public int getValueCount()
    {
        int result = 0;

        for(int i = 0; i < current_rings.Count; i++)
        {
            result += current_rings[i].getValue();
        }

        return result;
    }

    public Transform getPosition(int param)
    {
        return positions[param];
    }
}
