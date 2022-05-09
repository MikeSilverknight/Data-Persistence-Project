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
    [SerializeField] int Score1;
    [SerializeField] int Score2;
    [SerializeField] int Score3;
    int Score4;
    int ScoreTemp;
    [SerializeField] string Name1;
    [SerializeField] string Name2;
    [SerializeField] string Name3;
    string Name4;
    string NameTemp;

    // Start is called before the first frame update
    void Start()
    {
        HighScore1 = GameObject.Find("ScoreText1").GetComponent<Text>();
        HighScore2 = GameObject.Find("ScoreText2").GetComponent<Text>();
        HighScore3 = GameObject.Find("ScoreText3").GetComponent<Text>();
        
        LoadHighScores();

        ScoreTemp = DataManager.Instance.HighScore;
        NameTemp = DataManager.Instance.PlayerName;
        
        SortScores();
        
        ReloadScores();
        
        SaveHighScores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void ReloadScores()
    {
        HighScore1.text = $"{Score1} : {Name1}";
        HighScore2.text = $"{Score2} : {Name2}";
        HighScore3.text = $"{Score3} : {Name3}";
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

[System.Serializable]
    public class SaveData
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
    
    public void SortScores()
    {   
        if (ScoreTemp > Score1 && ScoreTemp > Score2 && ScoreTemp > Score3)
        {
            Score3 = Score4;
            Name3 = Name4;
            Score2 = Score3;
            Name2 = Name3;
            Score1 = Score2;
            Name1 = Name2;
            ScoreTemp = Score1;
            NameTemp = Name1;
            Debug.Log($"1st Place! {Score1}");
        } else if (ScoreTemp > Score2 && ScoreTemp > Score3)
        {
            Score3 = Score4;
            Name3 = Name4;
            Score2 = Score3;
            Name2 = Name3;
            ScoreTemp = Score2;
            NameTemp = Name2;
            Debug.Log($"2nd Place! {Score2}");
        } else if (ScoreTemp > Score3)
        {
            Score3 = Score4;
            Name3 = Name4;
            ScoreTemp = Score3;
            NameTemp = Name3;
            Debug.Log($"3rd Place! {Score3}");
        }
    }

    public void LoadHighScores()
    {
        if (Name1 == null)
        {
            Name1 = "AAA";
        }
        if (Name2 == null)
        {
            Name2 = "BBB";
        }
        if (Name3 == null)
        {
            Name3 = "CCC";
        }   
        
        string path = Application.persistentDataPath + "/savescores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score1 = data.Score1;
            Score2 = data.Score2;
            Score3 = data.Score3;
            Name1 = data.Name1;
            Name2 = data.Name2;
            Name3 = data.Name3;
        }
    }
}