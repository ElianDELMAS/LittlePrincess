using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public Animator cameraIntroAnimator;
    public FollowPlayer followPlayerCamera;

    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    void Awake()
    {
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Planet2")
        {
            StartIntro();
        }
    }

    public void StartIntro()
    {
        followPlayerCamera.enabled = false;
        cameraIntroAnimator.enabled = true;
        FreezePlayers(true);
    }

    public void StartCountdown()
    {
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Planet2")
        {
            followPlayerCamera.enabled = true;
            cameraIntroAnimator.enabled = false;
            lapTracker.displayUI();
            StartCoroutine("Countdown");
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        audioSource.PlayOneShot(lowBeep);
        Debug.Log("3");
        tricolorLights.SetProgress(1);

        yield return new WaitForSeconds(1);

        audioSource.PlayOneShot(lowBeep);
        Debug.Log("2");
        tricolorLights.SetProgress(2);

        yield return new WaitForSeconds(1);

        audioSource.PlayOneShot(lowBeep);
        Debug.Log("1");
        tricolorLights.SetProgress(3);

        yield return new WaitForSeconds(1);

        audioSource.PlayOneShot(highBeep);
        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        StartRacing();

        yield return new WaitForSeconds(2f);

        tricolorLights.SetAllLightsOff();
    }

    public void StartRacing()
    {
        FreezePlayers(false);
    }

    void FreezePlayers(bool freeze)
    {
        //freeze players here
        playerControls.setFrost(freeze);
        foreach (AIControls ai in aiControls) { ai.setFrost(freeze); }
    }
}