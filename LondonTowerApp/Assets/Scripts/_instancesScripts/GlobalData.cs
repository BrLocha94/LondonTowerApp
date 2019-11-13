using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;


public class GlobalData : MonoBehaviour
{
    PatientData patients_data;

    private static GlobalData _instance;
    public static GlobalData instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<GlobalData>();

        if (_instance == null)
        {
            GameObject instanceResource = Resources.Load("GlobalData") as GameObject;

            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<GlobalData>();
                DontDestroyOnLoad(instanceObject);
            }
        }

        return _instance;
    }


    void Start()
    {
        LoadData();
    }

    public void AddPatient(string name, int age, List<Storager> level_data)
    {
        Patient new_patient = new Patient(name, age, level_data);
        _instance.patients_data.AddPatient(new_patient);
        SaveData();
    }

    void SaveData()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<PatientData>(_instance.patients_data));
    }

    void LoadData()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            _instance.patients_data = Helper.Deserialize<PatientData>(PlayerPrefs.GetString("save"));
        }
        else
        {
            _instance.patients_data = new PatientData();
            SaveData();
        }
    }

    public int GetPatiensCount()
    {
        return _instance.patients_data.patients_list.Length;
    }

    public string GetPatientName(int index)
    {
        return _instance.patients_data.patients_list[index].name;
    }

    public string GetPatientAge(int index)
    {
        return _instance.patients_data.patients_list[index].age.ToString();
    }

    public string GetPatientDate(int index)
    {
        return _instance.patients_data.patients_list[index].date;
    }

    public List<Storager> GetPatientStorageData(int index)
    {
        return _instance.patients_data.patients_list[index].data;
    }

}

[System.Serializable]
public class PatientData
{
    public Patient[] patients_list;

    public PatientData()
    {
        patients_list = new Patient[0];
    }

    public void AddPatient(Patient param)
    {
        Patient[] new_list = new Patient[patients_list.Length + 1];
        for (int i = 0; i < patients_list.Length; i++)
        {
            new_list[i] = patients_list[i];
        }
        new_list[new_list.Length - 1] = param;

        this.patients_list = new_list;
    }
}

[System.Serializable]
public class Patient
{
    public string name;
    public int age;
    public string date;
    public List<Storager> data;

    public Patient()
    {
        this.name = "";
        this.age = 0;
        this.date = DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
        this.data = new List<Storager>();
    }

    public Patient(string new_name, int new_age, List<Storager> new_data)
    {
        this.name = new_name;
        this.age = new_age;
        this.date = DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
        this.data = new_data;
    }
}

[System.Serializable]
public class Storager
{
    public float time;
    public int movements;

    public Storager()
    {
        this.time = 0f;
        this.movements = 0;
    }

    public Storager(float new_time, int new_movements)
    {
        this.time = new_time;
        this.movements = new_movements;
    }
}

/*
void Start()
{
    /*
    string path;
    //string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");
    //path = "Assets/Resources/patients-data.json";

    path = Path.Combine(Application.persistentDataPath, "patients-data.json");
    //StreamReader reader = new StreamReader(path);
    //string data_text = reader.ReadToEnd();
    string data_text = File.ReadAllText(path);

    //Debug.Log(data_text);
    PatientData data = JsonUtility.FromJson<PatientData>(data_text);
    _instance.patients_data = data;
    //reader.Close();

    //Debug.Log("PATH : " + path);

    /*
    if (File.Exists(path))
    {
        string data_text = File.ReadAllText(path);
        PatientData data = JsonUtility.FromJson<PatientData>(data_text);
        //data.printData();
        _instance.patients_data = data;
        Debug.Log("Global params data loaded");
    }
    else
    {

    //path = Path.Combine("jar:file://" + Application.dataPath + "!assets/", "patients-data.json");

    //if (File.Exists(path))
    //{
    //    Debug.Log("File does not exists");
    //}
    //}
    
}

    void SaveData()
    {
        /*
        string path = Path.Combine(Application.persistentDataPath, "patients-data.json"); //path = "Assets/Resources/patients-data.json";

        string data_text = JsonUtility.ToJson(_instance.patients_data);
        File.WriteAllText(path, data_text);

        //StreamWriter writer = new StreamWriter(path, false);
        //string jsonData = JsonUtility.ToJson(_instance.patients_data, true);
        //writer.Write(jsonData);
        //writer.Close();

        //string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");

        //if (File.Exists(path))
        //{
        //    string jsonData = JsonUtility.ToJson(_instance.patients_data, true);
        //    File.WriteAllText(path, jsonData);
        //}
        
    }
*/
