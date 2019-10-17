using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int levels;

    string name = "";
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
        _instance.level_movements = new List<int>();

        for(int i = 0; i < levels; i++)
        {
            _instance.level_movements.Add(0);
        }
    }

    public List<int> getLevelMovements()
    {
        return _instance.level_movements;
    }

    public void setLevelMovement(int param, int value)
    {
        _instance.level_movements[param] = value;
    }

    public void setName(string value)
    {
        _instance.name = value;
    }

    public string getName()
    {
        return _instance.name;
    }
}
