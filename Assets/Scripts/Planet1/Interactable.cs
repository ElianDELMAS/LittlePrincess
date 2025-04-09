using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

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

    public bool hasVideo = false;
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    public RawImage videoDisplay;

    private bool isAnimationPlayed = false;
    private bool isAnimationPlaying = false;
    private bool isDialoguePlaying = false;
    private bool isVideoPlaying = false;
    private bool isCharacterAlreadyVisited = false;
    private bool isWaitingForDialogueEnd = false;

    private GameObject[] ballsBesideBaseballBat;
    private string objectName;

    private FirstPersonController firstPersonController;

    void Start()
    {
        objectName = gameObject.name.ToLower();
        if (objectName.Contains("baseball"))
        {
            ballsBesideBaseballBat = GameObject.FindGameObjectsWithTag("Ball2");
            activeBall("Ball2", false);
        }

        firstPersonController = FindObjectOfType<FirstPersonController>();

        if (dialogueManager != null)
        {
            dialogueManager.OnDialogueEnded.AddListener(OnDialogueEnded);
        }
    }

    void OnDestroy()
    {
        if (dialogueManager != null)
        {
            dialogueManager.OnDialogueEnded.RemoveListener(OnDialogueEnded);
        }
    }

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
        if (hasVideo) 
        {
            checkVideoIsPlaying();
        }
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
        bool isGlove = objectName.Contains("glove");

        if (isGlove)
        {
            StartDialogue();
            isWaitingForDialogueEnd = true;
            activeBall("Ball", false);
        }
        else
        {
            if (!isCharacterAlreadyVisited || !objectName.Contains("baseball"))
            {
                if (hasAnimation && mAnimator != null && !isCharacterAlreadyVisited)
                {
                        mAnimator.SetTrigger(animationTriggerName);
                        isAnimationPlaying = true;
                }
                else
                {
                    StartDialogue();
                }
            }
            else
            {
                activeBall("Ball2", true);
                StartDialogue2();
            }

        }
    }

    private void OnDialogueEnded()
    {
        if (isWaitingForDialogueEnd)
        {
            isWaitingForDialogueEnd = false;
            
            if (hasAnimation && mAnimator != null && !isCharacterAlreadyVisited)
            {
                mAnimator.SetTrigger(animationTriggerName);
                isAnimationPlaying = true;
            }
        }

        if (hasVideo)
        {
            StartVideo();
        }
    }

    private void OnAnimationFinished()
    {
        isAnimationPlaying = false;
        isAnimationPlayed = true;
        if (!objectName.Contains("glove"))
        {
            StartDialogue();
        }
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

    private void StartDialogue2()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue2();
        }
    }

    private void checkDialogueIsPlaying() {
        if (dialogueManager != null && dialogueManager.dialoguePanel != null)
        {
            isDialoguePlaying = dialogueManager.dialoguePanel.activeSelf;
        }
    }

    private void checkVideoIsPlaying() {
        isVideoPlaying = videoDisplay.gameObject.activeSelf;
    }

    private void activeBall(string tag, bool active) 
    {
        GameObject[] ballsList;
        if (tag == "Ball2")
        {
            ballsList = ballsBesideBaseballBat;
        }
        else 
        {
            ballsList = GameObject.FindGameObjectsWithTag(tag);
        }

        foreach (GameObject ball in ballsList)
        {
            ball.SetActive(active);
        }
    }

    void StartVideo()
    {
        videoDisplay.gameObject.SetActive(true);
        firstPersonController.activateFreezePlayer(true);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.clip = null;
        firstPersonController.activateFreezePlayer(false);
        videoDisplay.gameObject.SetActive(false);
    }

    public bool getIsAnimationIsPlaying()
    {
        return isAnimationPlaying;
    }

    public bool getIsDialogueIsPlaying()
    {
        return isDialoguePlaying;
    }

    public bool getIsVideoIsPlaying()
    {
        return isVideoPlaying;
    }
}
