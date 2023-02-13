using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New Scenario")]
public class ScenarioData : ScriptableObject
{
    public enum MenaceType
    {
        Wall,
        Ennenmy
    }
    public GameObject WallPrefab;
    public GameObject PiratePrefab;
    public List<SpawningMenace> Menaces;
    
}
