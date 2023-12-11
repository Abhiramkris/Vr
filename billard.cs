using UnityEngine;

public class StickController : MonoBehaviour
{
    public float stickSpeed = 5f;
    public float hitForce = 10f; // Adjust the hit force as needed
    public Rigidbody ball; // Reference to the ball's Rigidbody component

    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // Move the stick towards the mouse position
        transform.position = Vector3.Lerp(transform.position, new Vector3(worldMousePosition.x, transform.position.y, worldMousePosition.z), Time.deltaTime * stickSpeed);

        // Check for mouse click to hit the ball
        if (Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }

    void HitBall()
    {
        if (ball != null)
        {
            // Calculate the direction from the stick to the ball
            Vector3 hitDirection = (ball.transform.position - transform.position).normalized;

            // Apply force to the ball in the hit direction
            ball.AddForce(hitDirection * hitForce, ForceMode.Impulse);
        }
    }
}
