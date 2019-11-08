using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsController : MonoBehaviour
{
    public GameObject panel_list;
    public CardBox info_prefab;

	void Start ()
    {
        int count = GlobalData.instance().GetPatiensCount();

        for(int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(info_prefab.gameObject, panel_list.transform);
            newObject.GetComponent<CardBox>().UpdateCardInfo(i);
        }
	}
}
