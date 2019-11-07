using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    public GameController game_controller;

    [SerializeField]
    private GameObject button_start;
    [SerializeField]
    private InputField name_input_field;
    [SerializeField]
    private InputField age_input_field;

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

    public void CheckInputs()
    {
        if (name_input_field != null)
        {
            if (name_input_field.text.Length < 3)
            {
                button_start.SetActive(false);
                return;
            }
        }
        else
        {
            Debug.Log("Name input field not deffined");
            return;
        }

        if (age_input_field != null)
        {
            if (age_input_field.text.Length < 1)
            {
                button_start.SetActive(false);
                return;
            }
        }
        else
        {
            Debug.Log("Age input field not deffined");
            return;
        }

        button_start.SetActive(true);
    }

    public void InTransition()
    {
        StartCoroutine(InTransitionRoutine());
    }

    public void OutTransition()
    {


        StartCoroutine(OutTransitionRoutine());
    }

    IEnumerator InTransitionRoutine()
    {
        button_start.SetActive(false);

        iTween.ScaleTo(gameObject, iTween.Hash(
                                    "scale", new Vector3(1f, 1f, 0f),
                                    "time", 2f,
                                    "easetype", iTween.EaseType.easeOutElastic));

        yield return new WaitForSeconds(2f);
    }

    IEnumerator OutTransitionRoutine()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
                                    "scale", new Vector3(0f, 0f, 0f),
                                    "time", 0.7f,
                                    "easetype", iTween.EaseType.linear));

        yield return new WaitForSeconds(0.7f);

        game_controller.startGame();
    }
}
