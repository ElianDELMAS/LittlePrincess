using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private Transform player;
    public float destroyDistance = 15f; // Distance apr�s laquelle le sol est d�truit

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && transform.position.z < player.position.z - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
