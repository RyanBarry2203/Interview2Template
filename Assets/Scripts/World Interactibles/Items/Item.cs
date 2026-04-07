using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractible
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private GameObject itemGameObject;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }
    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        Debug.Log("Interacted with " + itemData.itemName);
        AddItemToInventory(itemGameObject);

    }
    private void AddItemToInventory(GameObject item)
    {
        playerInventory.AddToInventory(item);
        Destroy(itemGameObject);

    }
} 
