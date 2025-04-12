using UnityEngine;

public class Rotation : MonoBehaviour
{

     float _rotationSpeed = 100*1;

void Update () {

    
    // be sure to capitalize Rotate or you'll get errors
    transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
}
}
