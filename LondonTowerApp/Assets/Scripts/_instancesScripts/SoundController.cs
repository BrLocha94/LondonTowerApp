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

    [SerializeField]
    private AudioClip error;
    [SerializeField]
    private AudioClip flip;
    [SerializeField]
    private AudioClip movement;
    [SerializeField]
    private AudioClip game_clear;

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

    public bool GetEnabled()
    {
        return _instance.is_enabled;
    }

    public void ChangeEnabled()
    {
        _instance.is_enabled = !_instance.is_enabled;

        if (_instance.is_enabled == true)
        {
            _instance.background.mute = false;
            _instance.button.mute = false;
            _instance.sfx.mute = false;
            Debug.Log("Sound ON");
        }
        else
        {
            _instance.background.mute = true;
            _instance.button.mute = true;
            _instance.sfx.mute = true;
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

    public void playMovement()
    {
        if (_instance.is_enabled == true)
        {
            playMovement(_instance.movement);
        }
    }

    private void playMovement(AudioClip param)
    {
        _instance.sfx.clip = param;
        _instance.sfx.Play();
    }

    public void playError()
    {
        if (_instance.is_enabled == true)
        {
            playError(_instance.error);
        }
    }

    private void playError(AudioClip param)
    {
        _instance.sfx.clip = param;
        _instance.sfx.Play();
    }

    public void playFlip()
    {
        if (_instance.is_enabled == true)
        {
            playFlip(_instance.flip);
        }
    }

    private void playFlip(AudioClip param)
    {
        _instance.sfx.clip = param;
        _instance.sfx.Play();
    }

    public void playGameClear()
    {
        if (_instance.is_enabled == true)
        {
            playGameClear(_instance.game_clear);
        }
    }

    private void playGameClear(AudioClip param)
    {
        _instance.sfx.clip = param;
        _instance.sfx.Play();
    }
}
