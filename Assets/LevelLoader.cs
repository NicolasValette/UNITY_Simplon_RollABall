using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Animator _transition;
    [SerializeField]
    private float _transitionTime;
    [SerializeField]
    private string _gameSceneName;
    public void LoadGame()
    {
        StartCoroutine(LoadLevel(_gameSceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(sceneName);
    }

   
}
