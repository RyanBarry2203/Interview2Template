using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DoorEventChannel", menuName = "ScriptableObjects/EventChannels/DoorEventChannel")]
public class DoorEventChannel : ScriptableObject
{
    public UnityAction doorEvent;

    public void RaiseEvent()
    {
        doorEvent?.Invoke();

    }
}
