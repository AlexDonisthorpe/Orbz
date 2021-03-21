using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbzCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;
    [SerializeField] Texture2D redCursorTexture;
    [SerializeField] Texture2D blueCursorTexture;
    [SerializeField] Texture2D yellowCursorTexture;


    private Colours.ColourNames currentColor;

    void Start()
    {
        SetCursorColour(cursorTexture);
        currentColor = Colours.ColourNames.Purple;
    }

    private void SetCursorColour(Texture2D texture)
    {
        Cursor.SetCursor(texture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
    }

    public void SetColor(Colours.ColourNames newColor)
    {
        if(newColor == Colours.ColourNames.Blue)
        {
            SetCursorColour(redCursorTexture);
            currentColor = Colours.ColourNames.Red;
        } else if(newColor == Colours.ColourNames.Blue)
        {
            SetCursorColour(blueCursorTexture);
            currentColor = Colours.ColourNames.Blue;
        } else if(newColor == Colours.ColourNames.Yellow)
        {
            SetCursorColour(yellowCursorTexture);
            currentColor = Colours.ColourNames.Yellow;
        }
    }

    public Colours.ColourNames GetColor()
    {
        return currentColor;
    }
}
