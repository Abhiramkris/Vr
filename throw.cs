using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
public float throwForce = 10f; // Adjust this value to control the throw force.
 private Vector3 initialPosition;
private Rigidbody rb;

 private void Start()
 {
  rb = GetComponent<Rigidbody>();
  rb.isKinematic = true; // Disable physics initially.
  initialPosition = transform.position;
 }

private void Update()
{
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
