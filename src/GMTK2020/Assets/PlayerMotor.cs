using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector2 currentInput;
    public float speed = 5f;
    public float movementSmoothing = 0.05f;
    private Vector2 tmpVelocity = Vector2.zero;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetVelocity = currentInput * speed;

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref tmpVelocity, movementSmoothing);
    }

    public void SetInput(Vector2 input)
    {
        currentInput = input;
    }
}
