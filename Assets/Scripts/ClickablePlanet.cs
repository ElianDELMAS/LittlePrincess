using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class ClickablePlanet : MonoBehaviour
{
    public string levelName;
    public int requiredLevel = 1;
    public float hoverScale = 1.2f;
    public Color hoverColor = Color.yellow;

    private Vector3 originalScale;
    private Color originalColor;
    private Renderer rend;

    private void Start()
    {
        originalScale = transform.localScale;
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    private void OnMouseEnter()
    {
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
}
