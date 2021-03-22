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

        if(currentColour == Colours.ColourNames.Red)
        {
            material.SetColor("_EmissionColor", new Color32(40, 1, 0, 1));
        }
    }

    public Colours.ColourNames GetColour()
    {
        return currentColour;
    }
}
