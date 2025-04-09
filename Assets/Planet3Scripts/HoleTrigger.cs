using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            Debug.Log("Joueur tombé dans un trou");
        }
    }
}
