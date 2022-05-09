using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ScoreMenuUI : MonoBehaviour
{
    public Text HighScore1;
    public Text HighScore2;
    public Text HighScore3;
    public Text HighScoreTemp;
    int Score1;
    int Score2;
    int Score3;
    int ScoreTemp;
    string Name1;
    string Name2;
    string Name3;
    string NameTemp;
    public int[] HighScores;

    // Start is called before the first frame update
    void Start()
    {
        HighScores = new int[4]{Score1, Score2, Score3, ScoreTemp};
        
        SortScores();
        
        HighScore1.text = "{Score1} : {Name1}";
        HighScore2.text = "{Score2} : {Name2}";
        HighScore3.text = "{Score3} : {Name3}";
        HighScoreTemp.text = $"{DataManager.Instance.HighScore} : {DataManager.Instance.PlayerName}";
        
        NameTemp = DataManager.Instance.PlayerName;
        ScoreTemp = DataManager.Instance.HighScore;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SortScores()
    {   

        SaveHighScores();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

[System.Serializable]
    class SaveData
    {
        public int Score1;
        public int Score2;
        public int Score3;
        public string Name1;
        public string Name2;
        public string Name3;
    }

    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.Score1 = Score1;
        data.Score2 = Score2;
        data.Score3 = Score3;
        data.Name1 = Name1;
        data.Name2 = Name2;
        data.Name3 = Name3;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savescores.json", json);
    }
}