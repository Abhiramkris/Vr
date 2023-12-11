using UnityEngine;
public class MouseInteraction : MonoBehaviour
{
    private Rigidbody rb;
    public float throwForce = 10f;
    private bool isDragging = false;
    private float distanceToCamera;
 

    private void Start()
    {
     rb = GetComponent<Rigidbody>();
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
    }
 

    private void OnMouseDown()
    {
       isDragging = true;
        rb.isKinematic = true;
    }
 

    private void OnMouseUp()
    {
       isDragging = false;
        rb.isKinematic = false;
 

        // Calculate the force to apply based on mouse drag distance
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distanceToCamera;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 force = (worldPos - transform.position) * 10f; // Adjust the multiplier as needed
       
        // Apply the force to throw the ball
        rb.AddForce(force, ForceMode.Impulse);
    }
 

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceToCamera;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos;
     }
         if (Input.GetMouseButtonDown(0)) // Change to your desired input method.
        {
            ThrowObject();
        }
    }
        private void ThrowObject()
    {
        rb.isKinematic = false; // Enable physics.
        rb.velocity = Vector3.zero; // Reset the object's velocity.
        rb.angularVelocity = Vector3.zero; // Reset the object's angular velocity.
 

        Vector3 throwDirection = (transform.position - Camera.main.transform.position).normalized;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
 

        // Optional: Reset the object's position after throwing.
        // transform.position = initialPosition;
    }
 

}
