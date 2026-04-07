using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<ItemData> inventory = new List<ItemData>();

    [SerializeField] private InventoryEventChannel inventoryEventChannel;

    public void AddToInventory(ItemData item)
    {
            inventory.Add(item);
            Debug.Log("Added " + item.name + " to inventory.");

            inventoryEventChannel.RaiseEvent(item);
    }
}
