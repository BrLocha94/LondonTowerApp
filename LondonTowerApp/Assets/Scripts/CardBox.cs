using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBox : MonoBehaviour
{
    public Text text_name;
    public Text text_age;

    public void UpdateCardInfo(int value)
    {
        text_name.text = "Nome: " + GlobalData.instance().GetPatientName(value);
        text_age.text = "Idade: " + GlobalData.instance().GetPatientAge(value);
    }

    public string GetCardName(int value)
    {
        return GlobalData.instance().GetPatientName(value);
    }

    public void OnCardClicked()
    {
        ResultsController controller = GameObject.FindObjectOfType<ResultsController>();
        if (controller != null)
        {
            controller.InTransition(this);
        }
        else
            Debug.Log("Cant find results controller in the scene");
    }
}
