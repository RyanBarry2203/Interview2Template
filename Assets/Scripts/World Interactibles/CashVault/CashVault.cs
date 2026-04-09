using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashVault : MonoBehaviour, IInteractible
{
    [SerializeField] InteractEventChannel interactEventChannel;
    [SerializeField] InteractibleData interactibleData;
    private bool isInteracting = false;

    public bool CanInteract(GameObject interactor)
    {
        return true;
    }

    public void StopInteract(GameObject interactor)
    {
        isInteracting = false;
        interactEventChannel.StopRaise();
    }
    public void Interact(GameObject interactor)
    {
        Debug.Log("Interacted with Cash Vault");
        isInteracting = true;
        interactEventChannel.Raise(interactibleData.interactionCooldown, interactibleData.rewardDescription, isInteracting);
    }
}
