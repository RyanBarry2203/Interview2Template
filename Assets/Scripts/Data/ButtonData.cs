using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultButtondata", menuName = "Game Data/ Button")]
public class ButtonData : ScriptableObject
{
    [Header("Object to Spawn")]
    public GameObject objectToSpawn;

    [Header("Cooldown Data")]
    public float cooldownTime = 3f;
    public float lastInteractionTime = -100f;

}
