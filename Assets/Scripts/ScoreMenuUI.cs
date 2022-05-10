using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

[DefaultExecutionOrder(1000)]
public class ScoreMenuUI : MonoBehaviour
{
    public Text HighScore1;
    public Text HighScore2;
    public Text HighScore3;
    public Text YourScore;
    public int Score1;
    public int Score2;
    public int Score3;
    int Score4;
    public int ScoreTemp;
    public string Name1;
    public string Name2;
    public string Name3;
    string Name4;
    public string NameTemp;

    // Start is called before the first frame update
    void Start()
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
        
        HighScore1 = GameObject.Find("ScoreText1").GetComponent<Text>();
        HighScore2 = GameObject.Find("ScoreText2").GetComponent<Text>();
        HighScore3 = GameObject.Find("ScoreText3").GetComponent<Text>();
        YourScore = GameObject.Find("ScoreTextTemp").GetComponent<Text>();

        DataManager.Instance.LoadHighScores();

        Score1 = DataManager.Instance.Score1;
        Score2 = DataManager.Instance.Score2;
        Score3 = DataManager.Instance.Score3;
        Name1 = DataManager.Instance.Name1;
        Name2 = DataManager.Instance.Name2;
        Name3 = DataManager.Instance.Name3;

        ScoreTemp = DataManager.Instance.HighScoreTemp;
        NameTemp = DataManager.Instance.PlayerNameTemp;
        
        SortScores();
        
        DataManager.Instance.SaveHighScores();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HighScore1.text = $"{Score1} : {Name1}";
        HighScore2.text = $"{Score2} : {Name2}";
        HighScore3.text = $"{Score3} : {Name3}";
        YourScore.text = ScoreTemp + " : " + NameTemp;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
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
        } else if (ScoreTemp < Score1 && ScoreTemp > Score2 && ScoreTemp > Score3)
        {
            Score3 = Score4;
            Name3 = Name4;
            Score2 = Score3;
            Name2 = Name3;
            ScoreTemp = Score2;
            NameTemp = Name2;
            Debug.Log($"2nd Place! {Score2}");
        } else if (ScoreTemp < Score1 && ScoreTemp < Score2 && ScoreTemp > Score3)
        {
            Score3 = Score4;
            Name3 = Name4;
            ScoreTemp = Score3;
            NameTemp = Name3;
            Debug.Log($"3rd Place! {Score3}");
        } else if (ScoreTemp < Score1 && ScoreTemp < Score2 && ScoreTemp < Score3)
        {
            Debug.Log($"Too bad... {ScoreTemp}");
        }
    }

    
}