using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    private Vector3 nextSpawnPoint;
    private int groundCount = 0;

    void Start()
    {
        // Commence à z = 0
        nextSpawnPoint = Vector3.zero;

        // Générer les premiers segments
        for (int i = 0; i < 5;  i++)
        {
            SpawnGround();
        }
    }

    public void SpawnGround()
    {
        // Instancier un nouveau segment de sol
        GameObject ground = Instantiate(groundPrefab, nextSpawnPoint, Quaternion.identity);

        // Mettre à jour la position du prochain segment
        nextSpawnPoint += new Vector3(0, 0, 10);


        /**/
        Renderer renderer = ground.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Créer un nouveau matériau transparent pour URP
            Material transparentMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            // Définir le matériau pour être transparent
            transparentMaterial.SetFloat("_Surface", 1); // Mode Transparent
            transparentMaterial.SetFloat("_Blend", 2); // Alpha blending

            // Paramètres pour le blending alpha
            transparentMaterial.SetFloat("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            transparentMaterial.SetFloat("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            // Désactiver l'écriture dans le Z-buffer pour les objets transparents
            transparentMaterial.SetFloat("_ZWrite", 0);

            // Définir la file de rendu pour le transparent (3 000 pour les objets transparents)
            transparentMaterial.renderQueue = 3000;

            // Appliquer la couleur avec alpha 0 (transparent)
            transparentMaterial.color = new Color(9f / 255f, 12f / 255f, 31f / 255f, 0f); // Couleur #090c1f avec alpha 0

            // Appliquer le matériau au renderer de l'objet
            renderer.material = transparentMaterial;
        }

        groundCount++;
        /**/

        // Ajouter un script de destruction automatique
        ground.AddComponent<GroundMover>();

        // Ajouter le script pour générer le prochain segment
        ground.AddComponent<GroundTrigger>();
    }
}
