using UnityEngine;

public class SimonButtonController : MonoBehaviour
{
   private SpriteRenderer sprite;
   public int thisButtonNumber;
   private SimonSays gameManager;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameManager = FindAnyObjectByType<SimonSays>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }

    void OnMouseUp()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
        gameManager.ColourPressed(thisButtonNumber);
    }
}
