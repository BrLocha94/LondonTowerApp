using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    bool is_enabled = true;

    [SerializeField]
    private AudioSource background;
    [SerializeField]
    private AudioSource button;
    [SerializeField]
    private AudioSource sfx;

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
        {
            _instance.background.mute = true;
            _instance.button.mute = true;
            _instance.sfx.mute = true;
            Debug.Log("Sound ON");
        }
        else
        {
            _instance.background.mute = false;
            _instance.button.mute = false;
            _instance.sfx.mute = false;
            Debug.Log("Sound OFF");
        }
    }

    public void playBackground()
    {
        if(_instance.is_enabled == true)
            _instance.background.Play();
    }

    public void playButton()
    {
        Debug.Log("AQUI");
        if (_instance.is_enabled == true)
            _instance.button.Play();
    }

    public void playSfx(AudioClip param)
    {
        if (_instance.is_enabled == true)
        {
            _instance.sfx.clip = param;
            _instance.sfx.Play();
        }
    }
}
