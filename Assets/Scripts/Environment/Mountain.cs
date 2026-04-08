using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Mountain : MonoBehaviour, IIGrappleable
{
    private Rigidbody PlayerBody;
    private float grappleForce = 10f;

    private CancellationTokenSource cancellationTokenSource;
    public bool CanGrapple(GameObject grappler)
    {
        return true;
    }

    public void Grapple(GameObject grappler, RaycastHit targetPos)
    {
        PlayerBody = grappler.gameObject.GetComponent<Rigidbody>();

        Vector3 grappleDirection = (targetPos.point - grappler.transform.position).normalized;

        if (cancellationTokenSource != null)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }

        CancellationTokenSource newCancellationTokenSource = new CancellationTokenSource();

        _ = ApplyGrappleForce(grappleDirection, PlayerBody,newCancellationTokenSource);
    }
    public async Task ApplyGrappleForce(Vector3 grappleDirection, Rigidbody playerBody, CancellationTokenSource cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            playerBody.AddForce(grappleDirection * grappleForce, ForceMode.Acceleration);
            await Task.Yield();
        }

    }
}
