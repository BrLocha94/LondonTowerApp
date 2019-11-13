using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsWindow : MonoBehaviour
{
    public ResultsController controller;
    public Text title;
    public Text results_1;
    public Text results_2;

    void ProcessData(int index)
    {
        title.text = "NOME: " + GlobalData.instance().GetPatientName(index) + 
                            "    IDADE: " + GlobalData.instance().GetPatientAge(index) + 
                            " DATA: " + GlobalData.instance().GetPatientDate(index) ;

        List<Storager> list = GlobalData.instance().GetPatientStorageData(index);

        for(int i = 0; i < list.Count; i++)
        {
            if(i < 6)
                results_1.text += "Level " + (i + 1).ToString() + ": Tempo = " + list[i].time.ToString("F2") + ": Movimentos = " + list[i].movements + "\n";
            else
                results_2.text += "Level " + (i + 1).ToString() + ": Tempo = " + list[i].time.ToString("F2") + ": Movimentos = " + list[i].movements + "\n";
        }
    }

    public void InTransition(int index)
    {
        ProcessData(index);

        StartCoroutine(InTransitionRoutine());
    }

    public void OutTransition()
    {
        PlayerData.instance().SaveData();

        StartCoroutine(OutTransitionRoutine());
    }

    IEnumerator InTransitionRoutine()
    {
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

        yield return new WaitForSeconds(0.8f);

        controller.OutTransition();
    }
}
