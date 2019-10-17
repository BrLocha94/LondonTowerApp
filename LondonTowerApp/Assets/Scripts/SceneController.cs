using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void loadOpen()
    {
        SceneManager.LoadScene("Open", LoadSceneMode.Single);
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void loadResults()
    {
        SceneManager.LoadScene("Results", LoadSceneMode.Single);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
