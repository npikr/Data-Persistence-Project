using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string currentName;

    public string highesScoreName;
    public int highestPlayerPoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadNameAndScore();
        
    }

    [System.Serializable]
    class SaveData
    {
        public string highesScoreName;
        public int highestPlayerPoints;
    }
    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.highesScoreName = highesScoreName;
        data.highestPlayerPoints = highestPlayerPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highesScoreName = data.highesScoreName;
            highestPlayerPoints = data.highestPlayerPoints;

        }

        else
        {
            highesScoreName = "";
            highestPlayerPoints = 0;
        }



        }

}


