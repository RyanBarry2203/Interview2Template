using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    private void Update()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        Vector3 mousePosition = new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, playerCamera.transform.position.y);

        Vector3 worldMousePosition = playerCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.y = transform.position.y;

        Vector3 direction = worldMousePosition - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}

