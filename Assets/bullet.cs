using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
   public GameObject Bullet;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(Bullet, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
