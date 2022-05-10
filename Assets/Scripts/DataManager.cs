using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string PlayerNameTemp;
    public int HighScore;
    public int HighScoreTemp;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

[System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string PlayerNameTemp;
        public int HighScore;    
        public int HighScoreTemp;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.PlayerNameTemp = PlayerNameTemp;
        data.HighScore = HighScore;
        data.HighScoreTemp = HighScoreTemp;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            PlayerNameTemp = data.PlayerNameTemp;
            HighScore = data.HighScore;
            HighScoreTemp = data.HighScoreTemp;
        }
    }
}
