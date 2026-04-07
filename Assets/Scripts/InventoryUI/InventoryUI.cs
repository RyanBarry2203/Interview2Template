using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]private InventoryEventChannel inventoryEventChannel;
    private List <GameObject> inventoryToDraw = new List<GameObject>();

    private void OnEnable()
    {
        inventoryEventChannel.OnItemAdded += AddItemToInventory;
    }
    private void OnDisable()
    {
        inventoryEventChannel.OnItemAdded -= AddItemToInventory;
    }
    private void AddItemToInventory(GameObject item)
    {
        inventoryToDraw.Add(item);
    }
    private void OnGUI()
    {
        for (int i = 0; i < inventoryToDraw.Count; i++)
        {

            var itemDataComponent = inventoryToDraw[i].GetComponent<ItemData>();

            string itemName = itemDataComponent != null ? itemDataComponent.itemName : "Unknown Item";
            GUI.Label(new Rect(10, 10 + (i * 20), 200, 20), itemName);
        }
    }
}
