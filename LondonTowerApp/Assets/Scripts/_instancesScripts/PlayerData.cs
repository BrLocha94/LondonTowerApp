using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int levels;

    string player_name = "";
    int player_age = 0;
    List<Storager> player_level_data;
    
    
    private static PlayerData _instance;
    public static PlayerData instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<PlayerData>();

        if (_instance == null)
        {
            GameObject instanceResource = Resources.Load("PlayerData") as GameObject;

            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<PlayerData>();
                DontDestroyOnLoad(instanceObject);
            }
        }

        return _instance;
    }

    void Start()
    {
        StartData();
    }

    public void SaveData()
    {
        GlobalData.instance().AddPatient(_instance.player_name, _instance.player_age, _instance.player_level_data);
    }

    public void FlushData()
    {
        for (int i = _instance.player_level_data.Count - 1; i >= 0; i++)
        {
            _instance.player_level_data.RemoveAt(0);
        }

        StartData();
    }

    void StartData()
    {
        _instance.player_name = "";
        _instance.player_age = 0;
        _instance.player_level_data = new List<Storager>();
    }

    public void AddStorageItem(float new_time, int new_movements)
    {
        _instance.player_level_data.Add(new Storager(new_time, new_movements));
    }

    #region GETS AND SETS

    public void SetPlayerName(string value)
    {
        _instance.player_name = value;
    }

    public string GetPlayerName()
    {
        return _instance.player_name;
    }

    public void SetPlayerAge(int value)
    {
        _instance.player_age = value;
    }

    public int GetPlayerAge()
    {
        return _instance.player_age;
    }

    public List<Storager> GetPlayerLevelData()
    {
        return _instance.player_level_data;
    }

    public float GetPlayerTotalTime()
    {
        float count = 0f;

        Debug.Log(_instance.player_level_data.Count);

        for(int i = 0; i < _instance.player_level_data.Count; i++)
        {
            count += _instance.player_level_data[i].time;
        }

        Debug.Log("AQUI " + count);

        return count;
    }

    public float GetPlayerTotalMovements()
    {
        int count = 0;

        for (int i = 0; i < _instance.player_level_data.Count; i++)
        {
            count += _instance.player_level_data[i].movements;
        }

        Debug.Log("AQUI  2 " + count);

        return count;
    }

    #endregion
}
