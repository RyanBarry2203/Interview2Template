using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractible
{
    //[SerializeField]private ButtonData buttonData;

    //public void Interact()
    //{
    //    Debug.Log("Button Pressed");
    //    Instantiate(buttonData.objectToSpawn, transform.position + Vector3.up * 2, Quaternion.identity);

    //}
    //public bool CanInteract()
    //{
    //    if (Time.time < buttonData.lastInteractionTime + buttonData.cooldownTime)
    //    {
    //        Debug.Log("Button is on cooldown");
    //        return false;
    //    }
    //    else
    //    {
    //        buttonData.lastInteractionTime = Time.time;
    //        return true;
    //    }


    //}

    [SerializeField] private DoorEventChannel doorEventChannel;

    public void Interact(GameObject interactor)
    {
        Debug.Log("Button Pressed");
        doorEventChannel.RaiseEvent();
    }
    public bool CanInteract(GameObject interactor)
    {
        return true;
    }

    public void StopInteract(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }
}
