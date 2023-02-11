using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New Scenario")]
public class ScenarioData : ScriptableObject
{
    public GameObject WallPrefab;
    public List<SpawningWalls> Walls;

    
}
