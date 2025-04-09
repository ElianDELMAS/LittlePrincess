using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameLevelMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
