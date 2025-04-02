// following and modified https://discussions.unity.com/t/is-there-a-way-to-resize-the-cursor/236290/2
// Jack Glenn-Kennedy  T00063898   March 4, 2025

using UnityEngine;

public class CursorManager : MonoBehaviour
{


    public Texture2D cursorTex1;    
    public Texture2D cursorTex2;
    void Awake()
    {
        Cursor.SetCursor(cursorTex1, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.SetCursor(cursorTex2, Vector2.zero, CursorMode.ForceSoftware);

    }
}

