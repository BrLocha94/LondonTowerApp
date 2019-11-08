using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int levels;

    string player_name = "";
    int player_age = 0;
    List<int> level_movements;

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
        GlobalData.instance().AddPatient(_instance.player_name, _instance.player_age);
    }

    public void FlushData()
    {
        for (int i = 0; i < levels; i++)
        {
            _instance.level_movements.RemoveAt(0);
        }

        StartData();
    }

    void StartData()
    {
        _instance.level_movements = new List<int>();

        for (int i = 0; i < levels; i++)
        {
            _instance.level_movements.Add(0);
        }

        _instance.player_name = "";
        _instance.player_age = 0;
    }

    #region GETS AND SETS

    public List<int> GetLevelMovements()
    {
        return _instance.level_movements;
    }

    public void SetLevelMovement(int param, int value)
    {
        _instance.level_movements[param] = value;
    }

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

    #endregion
}
