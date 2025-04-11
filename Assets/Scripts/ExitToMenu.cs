using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMenu : MonoBehaviour
{
    public Button exitButton;
    public string menuSceneName = "GameLevelMenu";

    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(GoToMenu);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            GoToMenu();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
