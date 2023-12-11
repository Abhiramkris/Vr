// position will be reset once the speed is reduced 

using UnityEngine;

public class StrikerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveStriker();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a Rigidbody
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            // Start moving the striker towards the cursor
            StartMoving();
        }
    }

    void StartMoving()
    {
        isMoving = true;
        GetComponent<Rigidbody>().velocity = CalculateMoveDirection() * moveSpeed;
    }

    void MoveStriker()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Check if the magnitude of the velocity is very small
        if (rb.velocity.magnitude < 0.1f)
        {
            StopMoving();
        }
    }

    void StopMoving()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        isMoving = false;
    }

    Vector3 CalculateMoveDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            return (hitPoint - transform.position).normalized;
        }

        return Vector3.zero;
    }
}
