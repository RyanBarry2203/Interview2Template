using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public RaycastHit hit;
    private GameObject currentInteractible;
    private GameObject previousInteractible;

    private void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f, LayerMask.GetMask("Interactible")))
        {
            currentInteractible = hit.collider.gameObject;
            if (currentInteractible != previousInteractible)
            {
                Debug.Log("Can Interact with " + currentInteractible.name);
                previousInteractible = currentInteractible;
            }
        }
        else
        {
            currentInteractible = null;
            previousInteractible = null;
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        CastRay();

        if (context.performed && currentInteractible != null)
        {
            IInteractible interactible = currentInteractible.GetComponent<IInteractible>();
            if (interactible != null && interactible.CanInteract(this.gameObject) == true)
            {
                Debug.Log("Interacted with " + currentInteractible.name);
                interactible.Interact(this.gameObject);
            }
        }
        if (context.canceled && currentInteractible != null)
        {
            IInteractible interactible = currentInteractible.GetComponent<IInteractible>();
            if (interactible != null)
            {
                Debug.Log("Stopped Interacting with " + currentInteractible.name);
                interactible.StopInteract(this.gameObject);
            }
        }
    }

}



