using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Texture2D cursorOnmouse;
    public CursorMode cursormode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOnmouse, hotSpot, cursormode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursormode);
    }
}
