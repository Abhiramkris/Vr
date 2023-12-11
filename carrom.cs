using UnityEngine;

public class StrikerController : MonoBehaviour
{
    public float strikerSpeed = 10f;
    public float throwForceMultiplier = 2f;  // Adjust this multiplier for throwing force

    private bool isThrowing = false;

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButtonDown(0))
        {
            isThrowing = true;
        }

        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // Set the striker's velocity towards the mouse position
        if (isThrowing)
        {
            Vector3 targetPosition = new Vector3(worldMousePosition.x, transform.position.y, worldMousePosition.z);
            GetComponent<Rigidbody>().velocity = (targetPosition - transform.position).normalized * strikerSpeed;

            // Check for the left mouse button being released to stop throwing
            if (Input.GetMouseButtonUp(0))
            {
                isThrowing = false;
                StopStriker();
            }
        }
    }

    void StopStriker()
    {
        // Stop the striker's movement
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void ThrowStriker()
    {
        // Apply additional force for throwing when the left mouse button is clicked
        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * throwForceMultiplier, ForceMode.Impulse);
    }
}
