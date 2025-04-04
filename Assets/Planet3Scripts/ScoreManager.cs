using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement != null)
        {
            score += playerMovement.forwardSpeed * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }
}
