using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWindow : MonoBehaviour
{
    public GameController game_controller;

    void Start()
    {
        if (game_controller == null)
        {
            GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (controllerObject != null)
                game_controller = controllerObject.GetComponent<GameController>();
            else
                Debug.Log("Cant find game controller using tag");
        }
        else
            Debug.Log("Game Controller is not deffined");
    }

    public void inTransition()
    {
        Debug.Log("ENTROU");
        StartCoroutine(inTransitionRoutine());
    }

    public void outTransition()
    {
        StartCoroutine(outTransitionRoutine());
    }

    IEnumerator inTransitionRoutine()
    {
        Debug.Log("AQUI");
        iTween.ScaleTo(gameObject, iTween.Hash(
                                    "scale", new Vector3(1f, 1f, 0f),
                                    "time", 2f,
                                    "easetype", iTween.EaseType.easeOutElastic));

        yield return new WaitForSeconds(2f);
    }

    IEnumerator outTransitionRoutine()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
                                    "scale", new Vector3(0f, 0f, 0f),
                                    "time", 0.7f,
                                    "easetype", iTween.EaseType.linear));

        yield return new WaitForSeconds(0.7f);

        game_controller.startGame();
    }
}
