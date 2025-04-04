using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        this.forwardMoveSpeed = -20.0f;
        this.backwardMoveSpeed = 20.0f;
        this.steerSpeed = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y == 0) { speed = 0; }
        rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);

        // Steer
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }

    public Vector2 GetInput()
    {
        return this.input;
    }

    public float GetSpeed()
    {
        return rg.linearVelocity.magnitude;
    }
}
