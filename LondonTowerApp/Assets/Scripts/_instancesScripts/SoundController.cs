using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    bool is_enabled = false;

    private static SoundController _instance;
    public static SoundController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SoundController>();

        if(_instance == null)
        {
            GameObject instanceResource = Resources.Load("SoundController") as GameObject;

            if(instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<SoundController>();
                DontDestroyOnLoad(instanceObject);
            }
        }

        return _instance;
    }

    public bool getEnabled()
    {
        return _instance.is_enabled;
    }

    public void changeEnabled()
    {
        _instance.is_enabled = !_instance.is_enabled;

        if (_instance.is_enabled == true)
            Debug.Log("Sound ON");
        else
            Debug.Log("Sound OFF");
    }
}
