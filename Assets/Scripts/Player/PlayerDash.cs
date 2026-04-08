using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] DashData dashData;

    private Coroutine dashCoroutine;
    private Coroutine dashCooldownCoroutine;

    private Rigidbody playerRigidbody;
    private WaitForSeconds cachedCooldownWait;
    private WaitForFixedUpdate cachedFixedUpdateWait = new WaitForFixedUpdate();

    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        cachedCooldownWait = new WaitForSeconds(dashData.dashCooldown);
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && dashCooldownCoroutine == null)
        {
            dashCoroutine = StartCoroutine(DashCoroutine());

        }
    }
    private IEnumerator DashCoroutine()
    {
        float elapsedTime = 0f;

        playerRigidbody.useGravity = false;

        while (elapsedTime < dashData.dashDuration)
        {
            playerRigidbody.velocity = player.transform.forward * dashData.dashSpeed;
            elapsedTime += Time.deltaTime;
            yield return cachedFixedUpdateWait;
        }
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.useGravity = true;  
        dashCoroutine = null;

        dashCooldownCoroutine = StartCoroutine(DashCooldownCoroutine());
    }
    private IEnumerator DashCooldownCoroutine()
    {
        yield return cachedCooldownWait;
        dashCooldownCoroutine = null;
    }
}
