using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject wall;

    public Animator princessAnimator;

    private bool justFinishedDialogue2 = false;

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

    public LevelCompletion levelCompletion;

    public InteractableManager interactableManager;


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

            if (hasAnimation && mAnimator != null)
            {
                mAnimator.SetTrigger(animationTriggerName);
                isAnimationPlaying = true;
            }
        }

        if (objectName.Contains("baseball"))
        {
            destroyWall();
        }

        bool isGlove = objectName.Contains("glove");

        if (isGlove)
        {
            activeBall("Ball", false);
        }
        
        Debug.Log("Dialogue ended");
        if (justFinishedDialogue2 && objectName.Contains("baseball"))
        {
            Debug.Log("Dialogue 2 ended");
            justFinishedDialogue2 = false;

            if (princessAnimator != null)
            {
                if (interactableManager != null)
                {
                    Debug.Log("Hiding interaction UI");
                    interactableManager.trueAnimationPlayed();
                    interactableManager.HideInteractionUI();
                }
                Debug.Log("Princess animation started");
                VideoPlayer videoPlayer = princessAnimator.GetComponent<VideoPlayer>();
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoEnd;
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
            justFinishedDialogue2 = true;
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
        if (!objectName.Contains("baseball"))
        {
            videoDisplay.gameObject.SetActive(false);
            destroyWall();
        }

        if (levelCompletion != null && objectName.Contains("baseball"))
        {
            levelCompletion.CompleteLevel();
            int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
            Debug.Log("Level completed: " + levelReached);
            SceneManager.LoadScene("GameLevelMenu");
        }
    }

    public void destroyWall() 
    {
        wall.SetActive(false);
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
