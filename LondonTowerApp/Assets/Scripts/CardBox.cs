using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBox : MonoBehaviour
{
    public Text text_name;
    public Text text_age;
    public Text text_date;

    int index = 0;

    public void UpdateCardInfo()
    {
        text_name.text = "Nome: " + GlobalData.instance().GetPatientName(index);
        text_age.text = "Idade: " + GlobalData.instance().GetPatientAge(index);
        text_date.text = "Data: " + GlobalData.instance().GetPatientDate(index);
    }

    public string GetCardName()
    {
        return GlobalData.instance().GetPatientName(index);
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

    public void SetIndex(int value)
    {
        index = value;
    }

    public int GetIndex()
    {
        return index;
    }
}
