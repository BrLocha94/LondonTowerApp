using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


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
        string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");

        Debug.Log("PATH : " + path);

        if (File.Exists(path))
        {
            string data_text = File.ReadAllText(path);
            PatientData data = JsonUtility.FromJson<PatientData>(data_text);
            //data.printData();
            _instance.patients_data = data;
            Debug.Log("Global params data loaded");
        }
        else
            Debug.Log("File does not exists");
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

    [System.Serializable]
    public class PatientData
    {
        public Patient[] patients_list;
    }

    [System.Serializable]
    public class Patient
    {
        public string name;
        public int age;
    }
}
