using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;        
    }

    public static GameManager Instance;

    public string bestName = "";
    public int bestScore  = 0;

    public string username;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveScore(int currentScore)
    {
        if (currentScore > bestScore)
        {
            // Update best stats
            bestScore = currentScore;
            bestName = username;

            // Save best stats
            SaveData data = new SaveData();
            data.name = username;
            data.score = currentScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestName = data.name;
            bestScore = data.score;
        }
    }

}
