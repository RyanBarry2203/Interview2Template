using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekineticObject : MonoBehaviour, IInteractible
{
    [SerializeField] TelekineticEventChannel telekineticEventChannel;
    [SerializeField] Rigidbody myRigidbody; 
    
    void OnEnable()
    {
        telekineticEventChannel.dropped += ResetObject;
    }
    void OnDisable()
    {
        telekineticEventChannel.dropped -= ResetObject;
    }
    public bool CanInteract(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        telekineticEventChannel.Raise(interactor);
        myRigidbody.isKinematic = false;
        myRigidbody.useGravity = false;
        myRigidbody.mass = 0.1f;
    }
    void ResetObject()
    {
        myRigidbody.isKinematic = true;
        myRigidbody.useGravity = true;
        myRigidbody.mass = 1f;
    }
}
