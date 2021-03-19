using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCCarPlayerController : MonoBehaviour
{
    private float maxSpeed = 8f;
    private float acceleration = 10f;
    private float frictionCoef = 1.2f;
    private float rotationSpeed = 200f;
    private Rigidbody2D rb;
    private bool isDelayFinished = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(StartRaceDelay());
    }

    IEnumerator StartRaceDelay()
    {
        yield return new WaitForSeconds(5);
        isDelayFinished = true;
    }

    void FixedUpdate()
    {
        if (isDelayFinished)
        {
            HandleMovement();
            ApplyFriction();
        }
    }
    private void ApplyFriction()
    {
        if (rb.velocity.magnitude != 0)
            rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y) * frictionCoef);
    }

    private void HandleMovement()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (rb.velocity.magnitude != 0)
                rb.AddTorque(-rotationSpeed * 1000);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (rb.velocity.magnitude != 0)
                rb.AddTorque(rotationSpeed * 1000);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0 && rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.up * acceleration);
            }
            if (Input.GetAxis("Vertical") < 0 && rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.up * -acceleration);
            }

        }
        var directionDotProduct = Vector2.Dot(rb.velocity, transform.up);
        if (directionDotProduct > 0)
            rb.velocity = rb.velocity.magnitude * transform.up;
        else if(directionDotProduct < 0)
            rb.velocity = rb.velocity.magnitude * -transform.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.velocity = Vector2.zero;
        }
    }
}