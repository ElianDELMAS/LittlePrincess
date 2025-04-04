using UnityEngine;
using System.Collections.Generic;

public class GroundHole : MonoBehaviour
{
    public GameObject[] tiles;
    private float holeSize = 3f;
    private float offsetY = 0.2f; // Hauteur supplémentaire pour que le cylindre dépasse un peu

    void Start()
    {
        List<int> availableIndexes = new List<int> { 0, 1, 2, 3, 4 };

        int nbHoledLines = Random.Range(2, tiles.Length);
        for (int i = 0; i < nbHoledLines; i++)
        {
            int index = availableIndexes[Random.Range(0, availableIndexes.Count)];
            availableIndexes.Remove(index);

            CreateHole(index);
        }
    }

    void CreateHole(int holeIndex)
    {
        GameObject tile = tiles[holeIndex];

        // Réduire la taille de la tile pour simuler le trou
        Vector3 newScale = tile.transform.localScale;
        newScale.z -= holeSize;
        tile.transform.localScale = newScale;

        Vector3 newPos = tile.transform.position;
        newPos.z -= holeSize / 2; // Déplacer pour compenser la réduction
        tile.transform.position = newPos;

        // Créer un GameObject qui représente le trou (cylindre jaune)
        GameObject hole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        hole.name = "Hole";
        hole.transform.SetParent(tile.transform.parent);

        // Positionner le cylindre à l'emplacement du trou + hauteur ajustée
        hole.transform.position = newPos + new Vector3(0, offsetY, newScale.z / 2 + holeSize / 2);

        // Ajuster la taille du cylindre
        hole.transform.localScale = new Vector3(tile.transform.localScale.x * 0.4f, holeSize / 2, tile.transform.localScale.z * 0.25f);

        // Ajouter un tag "Hole"
        hole.tag = "Hole";

        // Changer la couleur du cylindre en jaune
        // Changer la couleur du cylindre en jaune transparent
        Renderer holeRenderer = hole.GetComponent<Renderer>();

        // Créer un nouveau matériau transparent
        Material transparentMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit")); // Pour URP
        transparentMaterial.SetFloat("_Surface", 1); // Mode Transparent
        transparentMaterial.SetFloat("_Blend", 2); // Alpha blending
        transparentMaterial.SetFloat("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        transparentMaterial.SetFloat("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        transparentMaterial.SetFloat("_ZWrite", 0);
        transparentMaterial.renderQueue = 3000;

        // Appliquer la couleur jaune avec transparence
        transparentMaterial.color = new Color(0, 0, 0, 0);

        // Assigner le matériau au cylindre
        holeRenderer.material = transparentMaterial;

        // Désactiver les ombres
        holeRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        holeRenderer.receiveShadows = false;




        // Désactiver le CapsuleCollider et ajouter un BoxCollider
        CapsuleCollider capsule = hole.GetComponent<CapsuleCollider>();
        if (capsule != null) Destroy(capsule); // Supprime le CapsuleCollider s'il existe

        BoxCollider holeCollider = hole.AddComponent<BoxCollider>(); // Ajoute un BoxCollider
        holeCollider.isTrigger = true; // Le rendre détectable sans collision physique
    }
}
