using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearWindow : MonoBehaviour
{
    public Manager manager;

    public void InTransition()
    {
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

        yield return new WaitForSeconds(0.7f);

        manager.changeScene("Results");
    }
}
