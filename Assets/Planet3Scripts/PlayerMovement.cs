using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // -2 = extreme gauche, -1 = gauche, 0 = centre, 1 = droite, 2 = extreme droite
    private int laneIndex = 0; 
    private float laneWidth = 2f;
    private float moveSpeed = 10f;
    public float forwardSpeed = 5f;
    public float acceleration = 0.1f;

    void Update()
    {
        // Déplacement vers la gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneIndex > -2)
        {
            laneIndex--;
        }
        // Déplacement vers la droite
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneIndex < 2)
        {
            laneIndex++;
        }

        // Calcul de la nouvelle position en fonction de la colonne choisie
        Vector3 targetPosition = new Vector3(laneIndex * laneWidth, transform.position.y, transform.position.z);

        // Déplacement progressif vers la position cible
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        // Faire avancer le joueur automatiquement en z
        transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);

        // Augmenter la vitesse progressivement
        forwardSpeed += acceleration * Time.deltaTime;
    }
}
