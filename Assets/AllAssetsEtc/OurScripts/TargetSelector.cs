using UnityEngine;
using UnityEngine.Rendering;
// for ball hiting boxes

public class TargetSelector : MonoBehaviour
{
   
   public Camera camera1;
   private Rigidbody rigidbody3;
   public float forceSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody3 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    Vector3 distanceToTarget = hitInfo.point - transform.position;
                    Vector3 forceDirection = distanceToTarget.normalized;

                    rigidbody3.AddForce(forceDirection * forceSize, ForceMode.Impulse);
                }
            }
        }
    }
}
