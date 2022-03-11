using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D mouseCursor;

    Vector2 hotSpot = new Vector2(0, 0);
    CursorMode cursorMode = CursorMode.Auto;
    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
