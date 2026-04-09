using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractible
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private GameObject itemGameObject;

    private PlayerInventory playerInventory;

    public bool CanInteract(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        Debug.Log("Interacted with " + itemData.itemName);
        AddItemToInventory(itemData, interactor);

    }

    public void StopInteract(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }

    private void AddItemToInventory(ItemData item, GameObject interactor)
    {
        interactor.GetComponent<PlayerInventory>().AddToInventory(item);
        Destroy(itemGameObject);

    }
} 
