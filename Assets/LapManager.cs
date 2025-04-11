using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public List<SimpleCheckpoint> checkpoints;
    public int totalLaps = 3;
    public UIManager ui;

    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    private PlayerRank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();

    public Animator princessAnimator;

    public LevelCompletion levelCompletion;

    public VideoPlayer videoPlayer;

    void Start()
    {
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Planet2")
        {
            // Get players in the scene
            foreach (CarIdentity carIdentity in GameObject.FindObjectsByType<CarIdentity>(FindObjectsSortMode.None))
            {
                playerRanks.Add(new PlayerRank(carIdentity));
            }
            ListenCheckpoints(true);
            ui.UpdateLapText("Tour " + playerRanks[0].lapNumber + " / " + totalLaps);
            mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Player");
        }
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (SimpleCheckpoint checkpoint in checkpoints)
        {
            if (subscribe) { checkpoint.onCheckpointEnter.AddListener(CheckpointActivated); }
            else { checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated); }
        }
    }

    public void playPrincessAnimation()
    {
        if (princessAnimator != null)
            {
                Debug.Log("Princess animation started");
                ui.hideContinueButton();
                if (videoPlayer != null && videoPlayer.clip != null)
                {
                    videoPlayer.gameObject.SetActive(true);
                    videoPlayer.Play();
                    videoPlayer.loopPointReached += OnVideoEnd;
                }
            }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (levelCompletion != null)
        {
            levelCompletion.CompleteLevel();
            int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
            Debug.Log("Level completed: " + levelReached);
            SceneManager.LoadScene("GameLevelMenu");
        }
    }

    public void CheckpointActivated(CarIdentity car, SimpleCheckpoint checkpoint)
    {
        PlayerRank player = playerRanks.Find((rank) => rank.identity == car);
        if (checkpoints.Contains(checkpoint) && player != null)
        {
            // if player has already finished don't do anything
            if (player.hasFinished) { return; }

            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && player.lastCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished)
            {
                player.lapNumber += 1;
                player.lastCheckpoint = 0;

                // if this was the final lap
                if (player.lapNumber > totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;

                    // if first winner, display its name
                    if (player.rank == 1)
                    {
                        Debug.Log(player.identity.driverName + " a gagné !");
                        ui.UpdateLapText(player.identity.driverName + " a gagné !");
                        ui.ShowContinueButton(playPrincessAnimation);
                    }
                    else if (player == mainPlayerRank)
                    {
                        ui.UpdateLapText("La Petite Princesse termine " + mainPlayerRank.rank + "ème.");
                        ui.ShowContinueButton(playPrincessAnimation);
                    }

                    if (player == mainPlayerRank) { onPlayerFinished.Invoke(); }
                }
                else
                {
                    Debug.Log(player.identity.driverName + ": tour " + player.lapNumber);
                    if (car.gameObject.tag == "Player") { ui.UpdateLapText("Tour " + player.lapNumber + " / " + totalLaps); }
                }
            }
            else if (checkpointNumber == player.lastCheckpoint + 1) // next checkpoint reached
            {
                player.lastCheckpoint += 1;
            }
        }
    }
}