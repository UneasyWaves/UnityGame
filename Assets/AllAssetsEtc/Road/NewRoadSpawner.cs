//Jack Glenn-Kennedy
using UnityEngine;
using UnityEngine.Rendering;

public class NewRoadSpawner : MonoBehaviour
{
    
    public GameObject road;
    private float spawnRate = 1;
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnRoad();
            timer = 0;
        }
        
    }

    void spawnRoad()
    {
        Instantiate(road, transform.position, transform.rotation);
    }
}
