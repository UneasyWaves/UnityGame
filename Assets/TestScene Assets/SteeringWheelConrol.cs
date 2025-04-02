using UnityEngine;

public class SteeringWheelConrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float turnSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        }
    }
}
