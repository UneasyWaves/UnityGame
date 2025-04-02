using UnityEngine;
// https://www.youtube.com/watch?v=ixWGbwrdNY0&t=187s
public class MouseController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D handInteract;
   
   public CursorMode cursorMode = CursorMode.Auto;
   public Vector2 hotspotMouse = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspotMouse, cursorMode);
    }

    
   

    public void OnMouseOver()
    {
        Cursor.SetCursor(handInteract, hotspotMouse, cursorMode);
    }


    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotspotMouse, cursorMode);
    }
}
