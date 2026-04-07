using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/ EventChannels/InventoryEventChannel")]
public class InventoryEventChannel : ScriptableObject
{

    public UnityAction <GameObject> OnItemAdded;

    public void RaiseEvent(GameObject item)
    {
        OnItemAdded?.Invoke(item);
    }

}
