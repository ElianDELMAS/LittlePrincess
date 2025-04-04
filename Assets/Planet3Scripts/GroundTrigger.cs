using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private bool hasSpawnedNext = false;

    private void OnTriggerEnter(Collider other)
    {

        // Quand ce segment atteint une position critique, on spawn le suivant
        if (!hasSpawnedNext && other.CompareTag("Player"))
        {
            hasSpawnedNext = true;
            FindObjectOfType<GroundSpawner>().SpawnGround();
        }
    }
}
