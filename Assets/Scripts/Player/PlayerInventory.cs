using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<GameObject> inventory = new List<GameObject>();

    [SerializeField] private InventoryEventChannel inventoryEventChannel;

    public void AddToInventory(GameObject item)
    {
            inventory.Add(item);
            Debug.Log("Added " + item.name + " to inventory.");

            inventoryEventChannel.RaiseEvent(item);
    }
}
