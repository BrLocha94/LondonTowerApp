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
        //string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");

        string path = "Assets/Resources/patients-data.json";

        StreamReader reader = new StreamReader(path);
        string data_text = reader.ReadToEnd();
        //Debug.Log(data_text);
        PatientData data = JsonUtility.FromJson<PatientData>(data_text);
        _instance.patients_data = data;
        reader.Close();

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
        */
        //path = Path.Combine("jar:file://" + Application.dataPath + "!assets/", "patients-data.json");

        //if (File.Exists(path))
        //{
        //    Debug.Log("File does not exists");
        //}
        //}
    }

    public void AddPatient(string name, int age)
    {
        Patient new_patient = new Patient(name, age);
        _instance.patients_data.AddPatient(new_patient);
        SaveData();
    }

    void SaveData()
    {
        string path = "Assets/Resources/patients-data.json";

        StreamWriter writer = new StreamWriter(path, false);
        string jsonData = JsonUtility.ToJson(_instance.patients_data, true);
        writer.Write(jsonData);
        writer.Close();

        //string path = Path.Combine(Application.streamingAssetsPath, "patients-data.json");

        //if (File.Exists(path))
        //{
        //    string jsonData = JsonUtility.ToJson(_instance.patients_data, true);
        //    File.WriteAllText(path, jsonData);
        //}
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

        public void AddPatient(Patient param)
        {
            Patient[] new_list = new Patient[patients_list.Length + 1];
            for(int i = 0; i < patients_list.Length; i++)
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

        public Patient() { }

        public Patient(string new_name, int new_age)
        {
            this.name = new_name;
            this.age = new_age;
        }
    }
}
