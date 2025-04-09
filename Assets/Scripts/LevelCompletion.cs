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
    }

    public void CompleteLevel()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (currentLevel > levelReached)
        {
            PlayerPrefs.SetInt("LevelReached", currentLevel);
            Debug.Log($"Niveau {currentLevel - 1} complété, le niveau {currentLevel} est maintenant débloqué !");
        }
    }
}
