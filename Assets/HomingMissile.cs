using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 10f; // Speed of the missile
    public float rotationSpeed = 200f; // Rotation speed of the missile
    public Transform target; // The target the missile will home towards

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the missile
    }

    // FixedUpdate is called at a fixed time interval and is better for physics calculations
    void FixedUpdate()
    {
        if (target != null)
        {
            // Get the direction to the target
            Vector2 direction = ((Vector2)target.position - rb.position).normalized;

            // Calculate the amount to rotate towards the target
            float rotateAmount = Vector3.Cross(transform.up, direction).z;

            // Apply rotation to the missile
            rb.angularVelocity = rotateAmount * rotationSpeed;

            // Move the missile forward in the direction it's facing
            rb.velocity = transform.up * speed ;
        }
    }
}