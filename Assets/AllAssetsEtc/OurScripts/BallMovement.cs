using UnityEngine;
// https://www.ketra-games.com/2020/10/unity-game-tutorial-colliding-with-obstacles.html
// Jack Glenn-Kennedy  T00063898 March 7 2025
public class BallMovement : MonoBehaviour
{
    
    public float forceSize;

    private Vector3 forceDirection;
    private Rigidbody rigidbody4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody4 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        forceDirection = new Vector3(horizontalInput, 0, verticalInput);
        forceDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Vector3 force = forceDirection * forceSize;

        rigidbody4.AddForce(force);
    }
}
