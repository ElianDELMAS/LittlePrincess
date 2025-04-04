using UnityEngine;

public class GroundMover : MonoBehaviour
{
    // Position où l'objet sera détruit
    private float destroyZ = -15f;

    void Update()
    {
        // Vérifier combien de segments de sol restent
        int groundCount = GameObject.FindGameObjectsWithTag("Ground").Length;

        // Ne pas supprimer si c'était le dernier segment
        if (transform.position.z < destroyZ && groundCount > 1)
        {
            Destroy(gameObject);
        }
    }
}
