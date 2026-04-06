using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorEventChannel doorEventChannel;
    [SerializeField] private DoorData doorData;

    private enum DoorState { Open, Closed, Opening, Closing }
    DoorState currentState = DoorState.Closed;

    private float openingSpeed = 2f;
    private float elapsed = 0f;

    private void Awake()
    {
        doorEventChannel.doorEvent += ToggleDoor;
    }
    private void ToggleDoor()
    {
        if (currentState == DoorState.Closed || currentState == DoorState.Closing)
        {
            OpenDoorAsync();
        }
        else if (currentState == DoorState.Open || currentState == DoorState.Opening)
        {
            CloseDoorAsync();
        }
    }

    private async void OpenDoorAsync()
    {
        while (elapsed! >= openingSpeed)
        {
            doorData.doorGameObject.transform.Rotate(Vector3.up, 90f * Time.deltaTime);
            elapsed += Time.deltaTime;
            await System.Threading.Tasks.Task.Yield();
        }
    }
    private async void CloseDoorAsync()
    {
        while (elapsed! >= openingSpeed)
        {
            doorData.doorGameObject.transform.Rotate(Vector3.up, -90f * Time.deltaTime);
            elapsed += Time.deltaTime;
            await System.Threading.Tasks.Task.Yield();
        }
    }



}
