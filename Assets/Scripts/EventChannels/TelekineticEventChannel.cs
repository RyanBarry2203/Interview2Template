using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Telekinetic Event Channel", menuName = "EventChannels/TelekineticEventChannel")]
public class TelekineticEventChannel : ScriptableObject
{
    public UnityAction<GameObject> interacted;
    public UnityAction dropped;

    public void Raise(GameObject interactor)
    {
        interacted?.Invoke(interactor);

    }
    public void RaiseDrop()
    {
            dropped?.Invoke();
    }

}
