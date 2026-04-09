using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractibleData", menuName = "ScriptableObjects/InteractibleData")]
public class InteractibleData : ScriptableObject
{
    [Header("Interactible Info")]
    public string interactibleName;
    public float interactionCooldown;
    public string rewardDescription;
}
