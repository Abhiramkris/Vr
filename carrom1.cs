using UnityEngine;

public class ObjectMover : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            StartMoving();
        }

        if (isMoving)
        {
            MoveObject();
        }
    }

    void StartMoving()
    {
        isMoving = true;
        GetComponent<Rigidbody>().velocity = CalculateMoveDirection() * moveSpeed;
    }

    void MoveObject()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Check if the magnitude of the velocity is very small
        if (rb.velocity.magnitude < 3f)
        {
            StopMoving();
        }
    }

    void StopMoving()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        isMoving = false;

        // Return the object to its initial position
        transform.position = initialPosition;
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
