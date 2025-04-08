using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public Image interactionImage;
    public Interactable[] interactables;

    private Interactable currentClosest;
    private bool isAnimationPlaying;
    private bool isDialoguePlaying;
    private bool isVideoPlaying;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (interactables == null || interactables.Length == 0 || player == null)
            return;

        CheckStatesAndClosest();

        bool canInteract = currentClosest != null && !isAnimationPlaying && !isDialoguePlaying && !isVideoPlaying;

        if (canInteract)
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

    void CheckStatesAndClosest()
    {
        float closestDistance = Mathf.Infinity;
        currentClosest = null;

        isAnimationPlaying = false;
        isDialoguePlaying = false;
        isVideoPlaying = false;

        foreach (var interactable in interactables)
        {
            if (interactable == null) continue;

            float dist = Vector3.Distance(player.transform.position, interactable.transform.position);
            if (dist <= interactable.interactionRadius && dist < closestDistance)
            {
                closestDistance = dist;
                currentClosest = interactable;
            }

            // Stop checking further if one is playing
            if (interactable.getIsAnimationIsPlaying())
                isAnimationPlaying = true;

            if (interactable.getIsDialogueIsPlaying())
                isDialoguePlaying = true;

            if (interactable.getIsVideoIsPlaying())
                isVideoPlaying = true;

            // Petit boost : si tout est true, pas besoin de continuer
            if (isAnimationPlaying && isDialoguePlaying && isVideoPlaying)
                break;
        }
    }

    void ShowInteractionUI(string message)
    {
        if (interactionText != null && !interactionText.gameObject.activeSelf)
        {
            interactionText.gameObject.SetActive(true);
        }

        if (interactionImage != null && !interactionImage.gameObject.activeSelf)
        {
            interactionImage.gameObject.SetActive(true);
        }

        if (interactionText != null)
        {
            interactionText.text = message;
        }
    }

    void HideInteractionUI()
    {
        if (interactionText != null && interactionText.gameObject.activeSelf)
            interactionText.gameObject.SetActive(false);

        if (interactionImage != null && interactionImage.gameObject.activeSelf)
            interactionImage.gameObject.SetActive(false);
    }
}
