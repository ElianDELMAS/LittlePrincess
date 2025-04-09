using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelMenu : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene("MainGameMenu");
    }
}
