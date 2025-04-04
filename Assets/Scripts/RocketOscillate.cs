using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketOscillate : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }

    void OnMouseDown()
    {
        Debug.Log("Fusée cliquée → Retour au menu");
        SceneManager.LoadScene("MainGameMenu");
    }
}
