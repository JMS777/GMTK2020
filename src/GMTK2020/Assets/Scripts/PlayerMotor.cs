using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector2 currentInput;
    public float speed = 5f;
    public float movementSmoothing = 0.05f;
    public float rotationSmooting = 10f;
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
        var targetDirection = new Vector3(rb.velocity.x, 1f, 0f).normalized;
        var angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        // Debug.Log($"angle={angle}, targetDirection={targetDirection}");
        // var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(targetDirection);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSmooting * Time.deltaTime); 
    }

    public void SetInput(Vector2 input)
    {
        currentInput = input;
    }
}
