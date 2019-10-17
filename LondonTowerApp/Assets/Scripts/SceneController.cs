using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    public static SceneController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SceneController>();

        if (_instance == null)
        {
            GameObject instanceResource = Resources.Load("SceneController") as GameObject;

            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<SceneController>();
                DontDestroyOnLoad(instanceObject);
            }
        }

        return _instance;
    }

    public void loadOpen()
    {
        StartCoroutine(loadOpenRoutine());
    }

    IEnumerator loadOpenRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Open", LoadSceneMode.Single);
    }

    public void loadTutorial()
    {
        StartCoroutine(loadTutorialRoutine());
    }

    IEnumerator loadTutorialRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void loadResults()
    {
        StartCoroutine(loadResultsRoutine());
    }

    IEnumerator loadResultsRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Results", LoadSceneMode.Single);
    }

    public void loadGame()
    {
        StartCoroutine(loadGameRoutine());
    }

    IEnumerator loadGameRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
