using UnityEngine;
// Jack Glenn-Kennedy
// first part of road spawning script
public class RoadSpawn : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
       
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
    }
}
