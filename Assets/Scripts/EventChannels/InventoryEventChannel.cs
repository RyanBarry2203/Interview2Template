using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/ EventChannels/InventoryEventChannel")]
public class InventoryEventChannel : ScriptableObject
{

    public UnityAction <ItemData> OnItemAdded;

    public void RaiseEvent(ItemData item)
    {
        OnItemAdded?.Invoke(item);
    }

}
