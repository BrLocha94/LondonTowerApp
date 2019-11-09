using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour
{
    public GameObject panel_list;
    public CardBox info_prefab;
    public InputField input_field;

    public GameObject block;
    public ResultsWindow results_window;

    List<CardBox> actual_cards = new List<CardBox>();

	void Start ()
    {
        if (info_prefab != null)
        {
            if (panel_list != null)
            {
                CreateAllPatientsList();
            }
            else
                Debug.Log("Panel list is not defined");
        }
        else
            Debug.Log("Cardbox is not defined");
    }

    void FlushData()
    {
        if (actual_cards.Count != 0)
        {
            for (int i = actual_cards.Count - 1; i >= 0; i--)
            {
                Destroy(actual_cards[i].gameObject);
            }
            actual_cards = new List<CardBox>();
        }
        else
            Debug.Log("List is empty");
    }

    void CreateAllPatientsList()
    {
        int count = GlobalData.instance().GetPatiensCount();

        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(info_prefab.gameObject, panel_list.transform);
            newObject.GetComponent<CardBox>().UpdateCardInfo(i);
            actual_cards.Add(newObject.GetComponent<CardBox>());
        }
    }

    public void InTransition(CardBox card)
    {
        if (results_window != null)
        {
            block.SetActive(true);
            results_window.InTransition();
        }
        else
            Debug.Log("Results window is not deffined");
    }

    public void OutTransition()
    {
        block.SetActive(false);
    }

    public void SearchForPatient()
    {
        if (input_field != null)
        {
            SearchForPatient(input_field.text);
        }
        else
            Debug.Log("Input field not defined");
    }

    private void SearchForPatient(string param)
    {
        if (param.Length > 0)
        {
            FlushData();

            int count = GlobalData.instance().GetPatiensCount();

            for (int i = 0; i < count; i++)
            {
                GameObject newObject = Instantiate(info_prefab.gameObject, panel_list.transform);
                if (newObject.GetComponent<CardBox>().GetCardName(i).Equals(param))
                {
                    newObject.GetComponent<CardBox>().UpdateCardInfo(i);
                    actual_cards.Add(newObject.GetComponent<CardBox>());
                }
                else
                    Destroy(newObject);
            }
        }
        else
        {
            int count = GlobalData.instance().GetPatiensCount();

            if (count != actual_cards.Count)
            {
                FlushData();
                CreateAllPatientsList();
            }
        }
    }
}
