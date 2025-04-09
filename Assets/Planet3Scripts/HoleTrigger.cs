using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;  // Nécessaire pour gérer les scènes
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;  // Nécessaire pour arrêter le jeu dans l'éditeur
#endif

public class HoleTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public GameObject gameManager;
    private Rigidbody playerRb;
    private Collider playerCollider;
    private bool gameOverTriggered = false;
    public Animator princessAnimator;
    public VideoPlayer videoPlayer;
    public LevelCompletion levelCompletion;

    void Start()
    {
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
            playerCollider = player.GetComponent<Collider>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole") && !gameOverTriggered)
        {
            gameOverTriggered = true;
            Debug.Log("Joueur tombé dans un trou");

            // Désactiver les scripts de mouvement
            if (player != null)
            {
                PlayerMovement movementScript = player.GetComponent<PlayerMovement>();
                if (movementScript != null)
                {
                    movementScript.enabled = false;
                }
            }

            if (mainCamera != null)
            {
                CameraFollow cameraScript = mainCamera.GetComponent<CameraFollow>();
                if (cameraScript != null)
                {
                    cameraScript.enabled = false;
                }
            }

            if (gameManager != null)
            {
                ScoreManager scoreScript = gameManager.GetComponent<ScoreManager>();
                if (scoreScript != null)
                {
                    scoreScript.enabled = false;
                }
            }

            // Lancer l'animation de Game Over
            StartCoroutine(GameOver());
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.clip = null;

        if (levelCompletion != null)
        {
            levelCompletion.CompleteLevel();
            SceneManager.LoadScene("GameLevelMenu");
        }
    }

    IEnumerator GameOver()
    {
        Debug.Log("Fin du jeu !");

        yield return new WaitForSeconds(1f); // Attente de 1 seconde avant la chute

        if (playerRb != null)
        {
            // Désactiver la physique et les collisions pendant la chute
            playerRb.isKinematic = true;  // Désactive la physique
            playerRb.useGravity = false;  // Désactive la gravité temporairement
            if (playerCollider != null)
            {
                playerCollider.enabled = false;  // Désactiver les collisions
            }

            // Réactiver la physique pour la chute (appliquer une force vers le bas)
            playerRb.isKinematic = false;  // Réactiver la physique
            playerRb.useGravity = true;    // Réactiver la gravité

            // Réactiver les collisions
            if (playerCollider != null)
            {
                playerCollider.enabled = true;  // Réactiver les collisions
            }

            // Appliquer une force vers le bas pour que le joueur tombe immédiatement
            playerRb.linearVelocity = Vector3.zero;  // Réinitialiser la vitesse du personnage
            playerRb.AddForce(Vector3.down * 10f, ForceMode.Impulse);  // Appliquer une impulsion vers le bas

            // Attendre un petit moment pour laisser le temps au personnage de commencer sa chute
            yield return new WaitForSeconds(0.1f);

            if (princessAnimator != null)
            {
                Debug.Log("Princess animation started");
                VideoPlayer videoPlayer = princessAnimator.GetComponent<VideoPlayer>();
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoEnd;
            }
        }
    }
}
