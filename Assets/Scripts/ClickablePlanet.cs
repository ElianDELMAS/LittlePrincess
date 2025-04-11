using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class ClickablePlanet : MonoBehaviour
{
    public string levelName;
    public int requiredLevel = 1;
    public float hoverScale = 1.2f;
    public Color hoverColor = Color.green;

    private Vector3 originalScale;
    private Color originalColor;
    private Renderer rend;
    private bool isUnlocked = false;
    public GameObject lockIcon;

    private void Start()
    {
        originalScale = transform.localScale;
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }

        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        isUnlocked = levelReached >= requiredLevel;

        if (!isUnlocked)
        {
            if (rend != null) rend.material.color = Color.gray;

            if (lockIcon != null) lockIcon.SetActive(true);
        }
        else
        {
            if (lockIcon != null) lockIcon.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        if (!isUnlocked) return;
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (levelReached >= requiredLevel)
        {
            transform.localScale = originalScale * hoverScale;
            if (rend != null) rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
        if (rend != null) rend.material.color = originalColor;
    }

    private void OnMouseDown()
    {
        if (!isUnlocked) return;
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if (levelReached >= requiredLevel)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("Niveau pas encore débloqué !");
        }
    }

    public void Highlight()
    {
        if (!isUnlocked) return;
        transform.localScale = originalScale * hoverScale;
        if (rend != null) rend.material.color = hoverColor;
    }

    public void ResetVisual()
    {
        transform.localScale = originalScale;
        if (rend != null) rend.material.color = originalColor;
    }

    public void Select()
    {
        if (!isUnlocked) return;
        SceneManager.LoadScene(levelName);
    }
}
