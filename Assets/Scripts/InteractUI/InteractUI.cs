using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class InteractUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] Image progressBar;
    [SerializeField] InteractEventChannel interactEventChannel;

    private Coroutine fillCoroutine;

    private void OnEnable()
    {
        interactEventChannel.OnInteract += HandleInteractStart;
        interactEventChannel.OnStopInteract += HandleInteractStop;
    }

    private void OnDisable()
    {
        interactEventChannel.OnInteract -= HandleInteractStart;
        interactEventChannel.OnStopInteract -= HandleInteractStop;
    }

    private void HandleInteractStart(float coolDownDur, string rewardDescription, bool isInteracting)
    {
        interactText.text = "Unlocking: " + rewardDescription;

        if (fillCoroutine != null) StopCoroutine(fillCoroutine);

        fillCoroutine = StartCoroutine(FillBarRoutine(coolDownDur));
    }

    private void HandleInteractStop()
    {
        interactText.text = "Press E to Interact";

        if (fillCoroutine != null) StopCoroutine(fillCoroutine);

        if (progressBar != null) progressBar.fillAmount = 0f;
    }

    private IEnumerator FillBarRoutine(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            if (progressBar != null)
            {
                progressBar.fillAmount = elapsedTime / duration;
            }

            yield return null;
        }

        interactText.text = "Unlocked!";
        if (progressBar != null) progressBar.fillAmount = 0f;
    }
}