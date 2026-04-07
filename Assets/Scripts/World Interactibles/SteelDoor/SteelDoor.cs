using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class SteelDoor : MonoBehaviour
{
    [SerializeField] PlateEventChannel plateChannel;
    [SerializeField] Transform origionalDoorPos;
    [SerializeField] Transform targetPos;
    [SerializeField] Transform currentDoorPos;

    private bool doorOpen = false;
    //private Transform currentDoorPos;

    private CancellationTokenSource cancellationTokenSource;

    private void Awake()
    {
        origionalDoorPos = this.transform;
        //currentDoorPos = origionalDoorPos;

    }
    void OnEnable()
    {
        plateChannel.OnPlatePressed += OpenDoor;
        plateChannel.OnPlateReleased += CloseDoor;
    }
    void OnDisable()
    {
        plateChannel.OnPlatePressed -= OpenDoor;
        plateChannel.OnPlateReleased -= CloseDoor;
    }
    private void OpenDoor()
    {
        if (cancellationTokenSource != null)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
        cancellationTokenSource = new CancellationTokenSource();

        _ = MoveDoorAsync();

    }
    private void CloseDoor()
    {
        if (cancellationTokenSource != null)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
        cancellationTokenSource = new CancellationTokenSource();
        _ = MoveDoorAsync();
    }
    private async Task MoveDoorAsync()
    {
        if (doorOpen)
        {
            currentDoorPos.position = targetPos.position;
            targetPos.position = origionalDoorPos.position;
            Debug.Log("Closing door...");
        }
        else
        {
            currentDoorPos = origionalDoorPos;
            Debug.Log("Opening door...");
        }

        float elapsed = 0f;
        float moveDuration = 2f;
        while (elapsed < moveDuration && currentDoorPos.position != targetPos.position)
        {
            if (cancellationTokenSource.Token.IsCancellationRequested)
            {
                return;
            }
            currentDoorPos.position = Vector3.Lerp(currentDoorPos.position, targetPos.position, elapsed / moveDuration);
            elapsed += Time.deltaTime;

            await Task.Yield();
        }

        if (elapsed >= moveDuration || currentDoorPos.position == targetPos.position)
        {
            Debug.Log("Door movement completed.");
            doorOpen = true;
            elapsed = 0;
            return;
        }
    }
}
