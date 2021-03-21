using UnityEngine;

public class Sphere : MonoBehaviour
{
    Colours.ColourNames currentColour;

    public void SetColour(Colours.ColourNames newColour)
    {
        var material = GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", Colours.ColourValue(newColour));
        material.SetColor("_EmissionColor", Colours.ColourValue(newColour));
        
        currentColour = newColour;
    }

    public Colours.ColourNames GetColour()
    {
        return currentColour;
    }
}
