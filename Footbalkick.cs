using UnityEngine;

public class FootballController : MonoBehaviour
{
    public float kickForce = 10f; // Adjust the force as needed
    public ForceMode forceMode = ForceMode.Impulse;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assumes left mouse button for kicking
        {
            Kick();
        }
    }

    void Kick()
    {
        // Add force to kick the football
        Vector3 kickDirection = CalculateKickDirection();
        GetComponent<Rigidbody>().AddForce(kickDirection * kickForce, forceMode);
    }

    Vector3 CalculateKickDirection()
    {
        // You can customize the kick direction based on your game's mechanics
        // For simplicity, let's use the forward direction of the football
        return transform.forward;
    }
}
