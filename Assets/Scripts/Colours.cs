using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours
{
    public enum ColourNames
    {
        Red,
        Blue,
        Yellow,
        Purple,
        Orange,
        Green
    }

    private static Hashtable ColourValues = new Hashtable
    {
        //TODO All six colours
        {ColourNames.Red, new Color32(254, 9, 0, 1) },
        {ColourNames.Blue, new Color32(0, 122, 254, 1) },
        {ColourNames.Yellow, new Color32(255, 255, 0, 1) },
        {ColourNames.Purple, new Color32(60, 0, 185, 1) },
        {ColourNames.Orange, new Color32(255, 55, 0, 1) },
        {ColourNames.Green, new Color32(0, 130, 18, 1) }
    };

    public static Color32 ColourValue(ColourNames color)
    {
        return (Color32)ColourValues[color];
    }
}
