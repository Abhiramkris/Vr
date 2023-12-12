using UnityEngine;

public class SimpleCubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        MoveCube();
    }

    void MoveCube()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
