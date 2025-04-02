using UnityEngine;

public class camerafollowinside : MonoBehaviour
{
    private Vector3 offset = new Vector3(-4f, 1f, .2f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
    }
}