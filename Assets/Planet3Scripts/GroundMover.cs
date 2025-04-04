using UnityEngine;

public class GroundMover : MonoBehaviour
{
    // Position o� l'objet sera d�truit
    private float destroyZ = -15f;

    void Update()
    {
        // V�rifier combien de segments de sol restent
        int groundCount = GameObject.FindGameObjectsWithTag("Ground").Length;

        // Ne pas supprimer si c'�tait le dernier segment
        if (transform.position.z < destroyZ && groundCount > 1)
        {
            Destroy(gameObject);
        }
    }
}
