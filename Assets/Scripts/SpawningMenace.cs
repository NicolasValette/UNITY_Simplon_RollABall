using System;
using UnityEngine;

[Serializable]
public class SpawningMenace
{
    public ScenarioData.MenaceType MenaceType;
    public Vector3 Position;
    public Quaternion Rotation;
    public int TargetNeeded;
}
