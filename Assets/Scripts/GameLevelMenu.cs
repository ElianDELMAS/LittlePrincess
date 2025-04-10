using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelMenu : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene("MainGameMenu");
    }

    public void ResetProgression()
    {
        PlayerPrefs.DeleteKey("LevelReached");

        PlayerPrefs.SetInt("LevelReached", 1);
        PlayerPrefs.Save();

        Debug.Log("Progression réinitialisée !");
    }
}
