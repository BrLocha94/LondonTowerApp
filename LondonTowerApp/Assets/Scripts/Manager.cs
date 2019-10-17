using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SoundController soundController;
    PlayerData playerData;

	void Start ()
    {
        soundController = SoundController.instance();
        playerData = PlayerData.instance();
	}
	
}
