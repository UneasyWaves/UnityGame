using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer2;
   // private CountdownAddMinusTime ms;
    
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        /* doesnt work, trying something else with seperate minus time attached to box object
        if (collision.gameObject.tag=="Player")//||other.gameObject.name.CompareTo("MinusTime2")==0)   // enter object to collide withs name*** like the hourgalss sprite etc - do this but minus time for objects that take away time
        {
           
           print("minus time "+ collision.gameObject.name);
            print("the time before is: " + ms.timeLeft);
            ms.timeLeft -= 115;
            if (ms.timeLeft<0) ms.timeLeft = 0;

            print("the time after is: " + ms.timeLeft);

            Destroy(collision.gameObject);
        }
        */

    }

    

}
