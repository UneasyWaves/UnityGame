// Jack Glenn-Kennedy   T00063898, April 3, 2025
// boxes to spawn at trigger point, destroyable with bullets etc.
// why does it spawn multiple of the prefab??

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class BoxesSpawn : MonoBehaviour 
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    //test time countdown added to this
    

    void Start()
    {
        
    }

   


//player gets rid of objects with bullets

// this is on the target script, not needed on this one

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        
        
    }
*/

    // test for time minus if hit as well
    private void OnTriggerEnter(Collider other)
    {
       
    
         Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        
       
       
        
    }

}
