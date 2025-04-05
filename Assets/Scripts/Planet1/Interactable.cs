using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interaction Settings")]
    public string interactionMessage = "Appuyez sur E pour interagir";
    public float interactionRadius = 40f;

    [Header("Dialogue & Animation")]
    public InkDialogueManager dialogueManager;
    public Animator mAnimator;
    public bool hasAnimation = false;
    public string animationTriggerName;

    private bool isAnimationPlayed = false;
    private bool isAnimationPlaying = false;
    private bool isDialoguePlaying = false;
    private bool isCharacterAlreadyVisited = false;

    void Update()
    {
        if (isAnimationPlaying && mAnimator != null)
        {
            AnimatorStateInfo stateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName(animationTriggerName) && stateInfo.normalizedTime >= 1.0f)
            {
                OnAnimationFinished();
            }
        }

        checkDialogueIsPlaying();
    }

    public bool CanInteract(Transform player)
    {
        if (isAnimationPlayed || isAnimationPlaying) return false;

        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= interactionRadius;
    }

    public string GetInteractionMessage()
    {
        return interactionMessage;
    }

    public void Interact()
    {
        if (hasAnimation && mAnimator != null)
        {
            mAnimator.SetTrigger(animationTriggerName);
            isAnimationPlaying = true;
        }
        else
        {
            StartDialogue();
        }
    }

    private void OnAnimationFinished()
    {
        isAnimationPlaying = false;
        isAnimationPlayed = true;
        StartDialogue();
    }

    private void StartDialogue()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue();
        }
        if (!isCharacterAlreadyVisited) 
        {
            interactionMessage += " une autre fois";
            isCharacterAlreadyVisited = true;
        }
    }

    private void checkDialogueIsPlaying() {
        if (dialogueManager != null && dialogueManager.dialoguePanel != null)
        {
            isDialoguePlaying = dialogueManager.dialoguePanel.activeSelf;
        }
    }

    public bool getIsAnimationIsPlaying()
    {
        return isAnimationPlaying;
    }

    public bool getIsDialogueIsPlaying()
    {
        return isDialoguePlaying;
    }
}
