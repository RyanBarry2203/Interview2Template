using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="Door Data", menuName = "Game Data/ Door")]
public class DoorData : ScriptableObject
{ 

    [Header("Door Object")]
    public GameObject doorGameObject;

    [Header("Opening/Closing Speed")]
    public float openingSpeed = 2f;

}
