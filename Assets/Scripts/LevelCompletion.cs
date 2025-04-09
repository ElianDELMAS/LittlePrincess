using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public int currentLevel = 1;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (currentLevel > levelReached)
        {
            Debug.Log("Ce niveau n'est pas encore débloqué.");
        }
        
        this.CompleteLevel();
    }

    public void CompleteLevel()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (currentLevel > levelReached)
        {
            PlayerPrefs.SetInt("LevelReached", currentLevel);
            Debug.Log($"Niveau {currentLevel} complété, le niveau {currentLevel + 1} est maintenant débloqué !");
        }
    }
}
