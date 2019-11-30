using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour {

    Sprite cursorArrow;
    Vector2 hotSpot;
    // Use this for initialization
    void Start()
    {
        hotSpot = GetComponent<SpriteRenderer>().sprite.pivot;
        Cursor.SetCursor(GetComponent<SpriteRenderer>().sprite.texture, hotSpot, CursorMode.ForceSoftware);
        

    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorArrow.texture, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow.texture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
