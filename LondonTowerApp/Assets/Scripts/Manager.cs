using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SoundController soundController;
    PlayerData playerData;
    SceneController sceneController;

	void Start ()
    {
        soundController = SoundController.instance();
        playerData = PlayerData.instance();
        sceneController = SceneController.instance();
	}
    
    public void changeScene(string param)
    {
        if (param.Equals("Game"))
            sceneController.loadGame();
        else if (param.Equals("Open"))
            sceneController.loadOpen();
        else if (param.Equals("Results"))
            sceneController.loadResults();
        else if (param.Equals("Tutorial"))
            sceneController.loadTutorial();
    }

}
