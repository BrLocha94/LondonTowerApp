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

}
