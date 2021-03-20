using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbzCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
    }
}
