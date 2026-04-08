using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour, IIGrappleable
{
    private Rigidbody playerBody;
    private float grappleForce = 10f;
    public bool CanGrapple(GameObject grappler)
    {
        return true;
    }

    public void Grapple(GameObject grappler, RaycastHit targetPos)
    {
        playerBody = grappler.gameObject.GetComponent<Rigidbody>();

        Vector3 grappleDirection = (targetPos.point - grappler.transform.position).normalized;

        while (Vector3.Distance(grappler.transform.position, targetPos.point) > 1f)
        {
            playerBody.AddForce(grappleDirection * grappleForce, ForceMode.Impulse);
        }
    }
}
