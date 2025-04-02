// following https://www.youtube.com/watch?v=zfUCf7_-dMs
// Jack Glenn-Kennedy T00063898 March 3, 2025
using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
       // LeftClick
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0 -LC");
            Debug.Log("World point: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        // RightClick
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 1 - RC");
        }

        // MiddleClick
        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse 2 - MC");
        }

    }
}
