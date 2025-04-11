using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public ClickablePlanet[] planets;
    private int currentIndex = 0;

    void Start()
    {
        if (planets.Length > 0)
        {
            HighlightPlanet(currentIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSelection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            TrySelectCurrent();
        }
    }

    void ChangeSelection(int direction)
    {
        planets[currentIndex].ResetVisual();

        currentIndex += direction;

        if (currentIndex < 0) currentIndex = planets.Length - 1;
        else if (currentIndex >= planets.Length) currentIndex = 0;

        HighlightPlanet(currentIndex);
    }

    void HighlightPlanet(int index)
    {
        planets[index].Highlight();
    }

    void TrySelectCurrent()
    {
        planets[currentIndex].Select();
    }
}
