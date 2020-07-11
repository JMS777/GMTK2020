using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput input;
    private InputAction moveAction;

    private PlayerMotor motor;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        motor = GetComponent<PlayerMotor>();
    }

    // Start is called before the first frame update
    void Start()
    {
        moveAction = input.actions.FindAction("Move");
        // moveAction.performed += OnMoveInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseControl.Instance.IsPaused)
            return;

        Vector2 inputValue = Vector2.zero;
        var value = moveAction.ReadValueAsObject();
        if (value != null)
        {
            inputValue = (Vector2)value;
        }
        
        motor.SetInput(inputValue);
    }
}
