using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Manager manager;
    public Text tutorial_text;

    int current_step = 0;

    [SerializeField]
    Image[] tutorial_steps;

    [SerializeField]
    string[] texts;

    void Start()
    {
        if (tutorial_text != null)
            tutorial_text.text = texts[0];
        else
            Debug.Log("Tutorial text is not found");
    }

    public void nextStep()
    {
        if(current_step >= tutorial_steps.Length - 1)
        {
            if (manager != null)
                manager.changeScene("Open");
            else
                Debug.Log("Manager not found");
        }
        else
        {
            tutorial_steps[current_step].gameObject.SetActive(false);
            current_step++;
            tutorial_steps[current_step].gameObject.SetActive(true);
            tutorial_text.text = texts[current_step];
        }
    }

    public void backStep()
    {
        if(current_step > 0)
        {
            tutorial_steps[current_step].gameObject.SetActive(false);
            current_step--;
            tutorial_steps[current_step].gameObject.SetActive(true);
            tutorial_text.text = texts[current_step];
        }
    }
}
