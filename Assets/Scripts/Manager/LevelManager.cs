using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private List<ScenarioData> ScenarioList;

    public ScenarioData GetScenarioLevel()
    {
        int ind = Random.Range (0, ScenarioList.Count);
        Debug.Log(ind);
        return ScenarioList[ind];
    }
}
