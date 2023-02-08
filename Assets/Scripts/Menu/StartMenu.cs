using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private string _gameSceneName;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
    
}
