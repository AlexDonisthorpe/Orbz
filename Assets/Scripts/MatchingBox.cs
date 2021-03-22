using UnityEngine;

public class MatchingBox : MonoBehaviour
{
    Colours.ColourNames[] coloursToChoose = { Colours.ColourNames.Purple, Colours.ColourNames.Orange, Colours.ColourNames.Green };
    Colours.ColourNames currentColour;

    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        GetRandomColour();
    }

    private void GetRandomColour()
    {
        var rendererMaterial = GetComponent<Renderer>().material;
        var newColour = coloursToChoose[Random.Range(0, 3)];

        rendererMaterial.SetColor("_Color", Colours.ColourValue(newColour));
        rendererMaterial.SetColor("_EmissionColor", Colours.ColourValue(newColour));
        currentColour = newColour;

        if(currentColour == Colours.ColourNames.Orange)
        {
            rendererMaterial.SetColor("_EmissionColor", new Color32(84, 5, 0, 1));
        }

        if (currentColour == Colours.ColourNames.Green)
        {
            rendererMaterial.SetColor("_EmissionColor", new Color32(0, 44, 0, 1));
        }

        Debug.Log($"Setting new colour: {currentColour.ToString()}");
    }

    public void HandleMatchingColour(Colours.ColourNames cursorColour, Colours.ColourNames orbColour)
    {
        bool doubleValue = false;
        
        if (currentColour == Colours.ColourNames.Green)
        {
            if(cursorColour == Colours.ColourNames.Blue && orbColour == Colours.ColourNames.Yellow)
            {
                doubleValue = true;
                GetRandomColour();
            } else if(cursorColour == Colours.ColourNames.Yellow && orbColour == Colours.ColourNames.Blue)
            {
                doubleValue = true;
                GetRandomColour();
            }
        }
        if (currentColour == Colours.ColourNames.Purple)
        {
            if (cursorColour == Colours.ColourNames.Blue && orbColour == Colours.ColourNames.Red)
            {
                doubleValue = true;
                GetRandomColour();
            }
            else if (cursorColour == Colours.ColourNames.Red && orbColour == Colours.ColourNames.Blue)
            {
                doubleValue = true;
                GetRandomColour();
            }
        }
        if (currentColour == Colours.ColourNames.Orange)
        {
            if (cursorColour == Colours.ColourNames.Red && orbColour == Colours.ColourNames.Yellow)
            {
                doubleValue = true;
                GetRandomColour();
            }
            else if (cursorColour == Colours.ColourNames.Yellow && orbColour == Colours.ColourNames.Red)
            {
                doubleValue = true;
                GetRandomColour();
            }
        }

        if(doubleValue)
        {
            _animator.SetTrigger("ScoreDoubled");
            FindObjectOfType<ScoreManager>().DoubleScore();
        }
    }
}
