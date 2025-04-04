using UnityEngine;

public class CubeTextureGenerator : MonoBehaviour
{
    private int textureSize = 16; // Taille de la texture (16x16)

    void Start()
    {
        ApplyTexture();
    }

    void ApplyTexture()
    {
        Texture2D texture = new Texture2D(textureSize, textureSize);
        texture.filterMode = FilterMode.Point; // Empêche l'effet flou
        texture.wrapMode = TextureWrapMode.Clamp;

        // Définition des couleurs pour les pixels
        Color[] pixelColors = new Color[]
        {
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.192f, 0.220f, 0.137f), // #313822

            // Deuxième ligne
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.212f, 0.255f, 0.153f), // #364127
            
            // Troisième ligne
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.212f, 0.211f, 0.211f), // #363536
            
            // Quatrième ligne
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.211f, 0.211f), // #363536

            // Cinquième ligne
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.211f, 0.211f), // #363536

            // Sixième ligne
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.192f, 0.220f, 0.137f), // #313822

            // Septième ligne
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.255f, 0.153f), // #364127

            // Huitième ligne
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b

            // Neuvième ligne
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.286f, 0.339f, 0.200f), // #495633

            // Dixième ligne
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.271f, 0.314f, 0.192f), // #455031

            // Onzième ligne
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c

            // Douxième ligne
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.368f, 0.361f, 0.368f), // #5e5c5e
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.325f, 0.321f, 0.325f), // #535253

            // Treizième ligne
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.271f, 0.314f, 0.192f), // #455031
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748

            // Quatorzième ligne
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.325f, 0.321f, 0.325f), // #535253
            new Color(0.286f, 0.339f, 0.200f), // #495633
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.282f, 0.278f, 0.282f), // #484748

            // Quinzième ligne
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.231f, 0.286f, 0.153f), // #3b4927
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.298f, 0.298f, 0.298f), // #4c4c4c
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.212f, 0.255f, 0.153f), // #364127
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.282f, 0.278f, 0.282f), // #484748
            new Color(0.251f, 0.255f, 0.251f), // #404140
            
            // Seizième ligne
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.212f, 0.211f, 0.211f), // #363536
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.231f, 0.231f, 0.231f), // #3b3b3b
            new Color(0.192f, 0.220f, 0.137f), // #313822
            new Color(0.192f, 0.220f, 0.137f), // #313822
        };

        // Appliquer les pixels ligne par ligne
        for (int y = 0; y < 16; y++) // Maintenant on remplit trois lignes
        {
            for (int x = 0; x < textureSize; x++)
            {
                int index = y * textureSize + x;
                texture.SetPixel(x, textureSize - 1 - y, pixelColors[index]);
            }
        }

        texture.Apply();

        // Appliquer la texture au matériau du cube
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = new Material(Shader.Find("Unlit/Texture"));
            renderer.material.mainTexture = texture;
        }
    }
}