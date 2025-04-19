using UnityEngine;
using UnityEngine.InputSystem;
// following YT KetreaGames for walkthrough
//Jack Glenn-Kennedy 
public class Driving : MonoBehaviour
{
   [SerializeField]
    private float speed;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private Rigidbody rigidBody;
    private Vector2 movementInput;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput,
       movementInput, ref movementInputSmoothVelocity, 0.1f);

        rigidBody.linearVelocity = smoothedMovementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
       movementInput = inputValue.Get<Vector2>();
    }


}
