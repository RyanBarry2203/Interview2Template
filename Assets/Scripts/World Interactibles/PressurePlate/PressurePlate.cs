using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Collider plateCollider;
    [SerializeField] Transform plateTransform;

    [SerializeField] PlateEventChannel plateChannel;

    private void Awake()
    {
        plateTransform = this.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            plateTransform.localPosition = new Vector3(plateTransform.localPosition.x, plateTransform.localPosition.y - 0.3f, plateTransform.localPosition.z);
            plateChannel.RaisePlatePressed();

        }
    }
    private void OnTriggerExit(Collider other)
   {
          if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
          {
                plateTransform.localPosition = new Vector3(plateTransform.localPosition.x, plateTransform.localPosition.y + 0.3f, plateTransform.localPosition.z);
                plateChannel.RaisePlateReleased();
        }
    }
}
