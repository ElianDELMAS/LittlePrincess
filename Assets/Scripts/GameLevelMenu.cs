using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelMenu : MonoBehaviour
{
    public Button planet1Button;
    public Button planet2Button;
    public Button planet3Button;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        planet1Button.interactable = true;
        planet2Button.interactable = (levelReached >= 2);
        planet3Button.interactable = (levelReached >= 3);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

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

// using UnityEngine;
// TODO: Add this script to each planets scripts
// public class Planet1 : MonoBehaviour
// {
//     public GameLevelMenu gameLevelMenu;

//     private void CompleteLevel()
//     {
//         gameLevelMenu.CompleteLevel(1);
//     }
// }
