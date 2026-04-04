using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    private void OnLook()
    {
        
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = playerCamera.transform.position.y; // Set the z-axis to the camera's height
        Vector3 worldMousePosition = playerCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.y = transform.position.y; // Keep the y-axis the same as the player's position
        Vector3 direction = worldMousePosition - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
