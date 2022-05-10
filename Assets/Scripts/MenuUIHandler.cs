using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    
    public InputField NameEntry;
    public Button StartButton;
    public bool NameFull;

    // Start is called before the first frame update
    void Start()
    {
        NameFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ScoreMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void AutoCapitalize()
    {
        NameEntry.text = NameEntry.text.ToUpper();
    }

    public void SaveNameTemp()
    {
        if (NameEntry.text.Length == 3)
        {
            DataManager.Instance.PlayerNameTemp = NameEntry.text;
            StartButton.interactable = true;
        } else if (NameEntry.text.Length < 3)
        {
            NameFull = false;
        }
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif        
    }
}
