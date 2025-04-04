using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private Transform player;
    public float destroyDistance = 15f; // Distance après laquelle le sol est détruit

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
