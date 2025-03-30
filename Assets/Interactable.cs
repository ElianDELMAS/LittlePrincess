using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Interactable : MonoBehaviour
{
    public string interactionMessage = "Vous avez interagi avec l'objet !";
    public float interactionRadius = 40f;
    public TextMeshProUGUI interactionText;
    public Image interactionImage;

    public InkDialogueManager dialogueManager;
    private Animator mAnimator;

    private string interactionMessageBaseball = "Press E to interact with Billy the Baseball Bat";
    private string interactionMessageChess = "Press E to interact with the Chess pieces";

    private bool isAnimationPlayed = false;
    private bool isAnimationPlaying = false;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        DisplayUI(false);
    }

    private void Update()
    {
        CheckForInteraction();
        
        if (isAnimationPlaying && mAnimator != null)
        {
            AnimatorStateInfo stateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);
            
            if (stateInfo.IsName("PlayBaseball") && stateInfo.normalizedTime >= 1.0f)
            {
                OnAnimationFinished();
            }
        }
    }


    private void CheckForInteraction()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance <= interactionRadius && !isAnimationPlayed && !isAnimationPlaying)
        {
            DisplayUI(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else
        {
            DisplayUI(false);
        }
    }

    private void DisplayUI(bool activate)
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(activate);
            interactionText.text = interactionMessageBaseball;
        }

        if (interactionImage != null)
        {
            interactionImage.gameObject.SetActive(activate);
        }
    }

    private void StartDialogue()
    {
        dialogueManager.StartDialogue();
    }

    public void Interact()
    {
        if (mAnimator != null)
        {
            mAnimator.SetTrigger("PlayBaseball");
            isAnimationPlaying = true;
        }
    }

    private void OnAnimationFinished()
    {
        isAnimationPlaying = false;
        isAnimationPlayed = true;
        Thread.Sleep(1000);
        StartDialogue();
    }
}
