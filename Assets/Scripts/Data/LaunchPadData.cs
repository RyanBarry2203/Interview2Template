using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launch Pad Data", menuName = "GameData/LaunchPadData")]
public class LaunchPadData : ScriptableObject
{
    [Header("How far dyou wanna launch him")]
    public float launchForce = 1000f;
}
