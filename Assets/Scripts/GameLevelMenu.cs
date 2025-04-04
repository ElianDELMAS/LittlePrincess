using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelMenu : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene("MainGameMenu");
    }

    public void CompleteLevel(int levelNumber)
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (levelNumber >= levelReached)
        {
            PlayerPrefs.SetInt("LevelReached", levelNumber + 1);
        }
    }
}
