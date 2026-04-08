using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash Daat", menuName = "GameData/ Dashdata")]
public class DashData : ScriptableObject
{
    [Header("Dash Data")]
    public float dashDuration = 0.5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 1f;

}
