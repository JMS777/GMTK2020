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

    }

    public void SetInput(Vector2 input)
    {
        currentInput = input;

        float rotationMax = 45;
        var targetDirection = new Vector3(0f, 0f, 0f);

        if(input.x == 0){
            targetDirection.z = 0f;
        } else {
            if(input.x<0){
                targetDirection.z = -rotationMax;
            } else {
                targetDirection.z = rotationMax;
            }
        }

        Quaternion targetRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetDirection),movementSmoothing);



        transform.rotation = targetRotation;
    }
}
