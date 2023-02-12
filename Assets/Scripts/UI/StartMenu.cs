using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

   
    
}
