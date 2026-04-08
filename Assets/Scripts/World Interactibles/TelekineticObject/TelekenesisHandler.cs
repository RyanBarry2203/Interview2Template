using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekenesisHandler : MonoBehaviour
{
    [SerializeField] TelekineticEventChannel telekineticEventChannel;
    [SerializeField] GameObject worldObject;
    private Vector3 rayCastEndPoint;
    private Vector3 lastObjectPosition;
    private Vector3 currentObjectPos;

    private void OnEnable()
    {
        telekineticEventChannel.interacted += HandleTelekineticEvent;
    }
    private void OnDisable()
    {
        telekineticEventChannel.interacted -= HandleTelekineticEvent;
    }
    private void HandleTelekineticEvent(GameObject player)
    {
        rayCastEndPoint = player.GetComponent<PlayerInteraction>().hit.transform.position;
        lastObjectPosition = worldObject.transform.position;

    }
    private void FixedUpdate()
    {
        if (rayCastEndPoint != Vector3.zero && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Moving Object");
            currentObjectPos = Vector3.Lerp(lastObjectPosition, rayCastEndPoint, 2f);
            worldObject.transform.position = currentObjectPos;
        }
        else
        {
            telekineticEventChannel.RaiseDrop();
        }
    }
}

