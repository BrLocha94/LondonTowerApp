using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShiffter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    public bool is_sound;

    int index = 0;

	void Start ()
    {
		if(is_sound == true)
        {
            bool result = SoundController.instance().GetEnabled();

            if (result == true)
            {
                gameObject.GetComponent<Image>().sprite = sprites[0];
                index = 0;
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = sprites[1];
                index = 1;
            }
        }
	}
	
    public void ChangeSprite()
    {
        if (index == 0)
            index = 1;
        else
            index = 0;

        gameObject.GetComponent<Image>().sprite = sprites[index];
    }
}
