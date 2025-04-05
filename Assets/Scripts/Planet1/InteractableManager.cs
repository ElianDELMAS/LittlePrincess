using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public Image interactionImage;
    public Interactable[] interactables;

    private Interactable currentClosest;
    private bool isAnimationPlaying;
    private bool isDialoguePlaying;

    void Update()
    {
        FindIfAnAnimationIsPlaying();
        FindIfADialogueIsPlaying();
        FindClosestInteractable();

        if (currentClosest != null && !isAnimationPlaying && !isDialoguePlaying)
        {
            ShowInteractionUI(currentClosest.interactionMessage);

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentClosest.Interact();
                HideInteractionUI();
            }
        }
        else
        {
            HideInteractionUI();
        }
    }

    void FindClosestInteractable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float closestDistance = Mathf.Infinity;
        currentClosest = null;

        foreach (var interactable in interactables)
        {
            float dist = Vector3.Distance(player.transform.position, interactable.transform.position);
            if (dist <= interactable.interactionRadius && dist < closestDistance)
            {
                closestDistance = dist;
                currentClosest = interactable;
            }
        }
    }

    void FindIfAnAnimationIsPlaying()
    {
        int count = 0;
        foreach (var interactable in interactables)
        {
            if (!interactable.getIsAnimationIsPlaying()) count++;
        }
        if (count == interactables.Length) isAnimationPlaying = false;
        else isAnimationPlaying = true;
    }

    void FindIfADialogueIsPlaying()
    {
        int count = 0;
        foreach (var interactable in interactables)
        {
            if (!interactable.getIsDialogueIsPlaying()) count++;
        }
        if (count == interactables.Length) isDialoguePlaying = false;
        else isDialoguePlaying = true;
    } 

    void ShowInteractionUI(string message)
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = message;
        }

        if (interactionImage != null)
        {
            interactionImage.gameObject.SetActive(true);
        }
    }

    void HideInteractionUI()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false);

        if (interactionImage != null)
            interactionImage.gameObject.SetActive(false);
    }
}
