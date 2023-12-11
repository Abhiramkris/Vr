using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour
{
public float moveSpeed = 10f;
public float turnSpeed = 50f;
private Rigidbody rb;
private void Start()
{
rb = GetComponent<Rigidbody>();
}
private void FixedUpdate()
{
float horizontalInput = Input.GetAxis("Horizontal");
float verticalInput = Input.GetAxis("Vertical");
Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
Quaternion rotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
rb.MovePosition(rb.position + movement);
rb.MoveRotation(rb.rotation * rotation);
}}
