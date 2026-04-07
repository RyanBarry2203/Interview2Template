using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]private InventoryEventChannel inventoryEventChannel;
    private List <ItemData> inventoryToDraw = new List<ItemData>();

    [SerializeField] private TextMeshProUGUI inventoryTextDisplay;

    private void OnEnable()
    {
        inventoryEventChannel.OnItemAdded += AddItemToInventory;
    }
    private void OnDisable()
    {
        inventoryEventChannel.OnItemAdded -= AddItemToInventory;
    }
    private void AddItemToInventory(ItemData item)
    {
        inventoryToDraw.Add(item);

        StringBuilder sb = new StringBuilder();

        sb.Append("Inventory : \n");

        foreach (var invItem in inventoryToDraw)
        {
            sb.AppendLine(invItem.itemName);
        }

        inventoryTextDisplay.text = sb.ToString();

    }
    //private void OnGUI()
    //{
    //    for (int i = 0; i < inventoryToDraw.Count; i++)
    //    {

    //        var itemDataComponent = inventoryToDraw[i].itemName;

    //        string itemName = itemDataComponent != null ? itemDataComponent : "Unknown Item";
    //        GUI.Label(new Rect(10, 10 + (i * 20), 200, 20), itemName);
    //    }
    //}
}
