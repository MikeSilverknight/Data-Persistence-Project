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

    // Start is called before the first frame update
    void Start()
    {
        
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
        DataManager.Instance.TempPlayerName = NameEntry.text;
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
