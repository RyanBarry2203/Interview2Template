using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]public float speed = 5f;

    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
