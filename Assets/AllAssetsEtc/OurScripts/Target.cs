using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer2 = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        renderer2.material.color = Color.white;
    }

    private void OnMouseExit()
    {
        renderer2.material.color = Color.blue;
    }
}
