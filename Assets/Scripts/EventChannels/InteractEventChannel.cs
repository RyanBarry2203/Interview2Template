using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InteractEventChannel", menuName = "EventChannel/InteractEventChannel")]
public class InteractEventChannel : ScriptableObject
{
    public UnityAction<float, string, bool> OnInteract;
    public UnityAction OnStopInteract;

    public void Raise(float coolDownDur, string rewardDescription, bool isInteracting)
    {
        OnInteract?.Invoke(coolDownDur, rewardDescription, isInteracting);
    }

    public void StopRaise()
    {
        OnStopInteract?.Invoke();
    }

}
