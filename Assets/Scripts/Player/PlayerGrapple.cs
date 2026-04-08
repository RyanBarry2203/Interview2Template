using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrapple : MonoBehaviour
{
    [SerializeField] GameObject player;
    private RaycastHit grappleTarget;

    void CastRay()
    {
        // Cast a ray from the player's position in the forward direction to find a grapple target
        if (Physics.Raycast(transform.position, transform.forward, out grappleTarget, 25f, LayerMask.GetMask("Grappleable")))
        {
            Debug.Log("Grapple target found: " + grappleTarget.collider.gameObject.name);
            
        }
        else
        {
            Debug.Log("No grapple target found.");
        }

    }
    public void OnGrapple(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CastRay();
            if (grappleTarget.collider != null)
            {
                IIGrappleable grappleable = grappleTarget.collider.gameObject.GetComponent<IIGrappleable>();
                if (grappleable != null && grappleable.CanGrapple(this.gameObject) == true)
                {
                    Debug.Log("Grappling to " + grappleTarget.collider.gameObject.name);
                    grappleable.Grapple(this.gameObject, grappleTarget);
                }
            }
        }
    }


}
