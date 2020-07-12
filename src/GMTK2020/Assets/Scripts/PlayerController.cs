using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action PlayerDied;
    public event Action PlayerWin;
    public event Action<int> PlayerDeepFied;

    public int lives = 4;
    public int DeepFryLevel { get; private set; } = 0;

    private PlayerRandomMovement randomMovement;
    private PlayerInputController playerInput;
    private PlayerMotor motor;
    private PlayerCollisionController playerCollision;
    
    private Animator animator;

    private void Awake()
    {
        randomMovement = GetComponentInChildren<PlayerRandomMovement>();
        animator = GetComponentInChildren<Animator>();
        motor = GetComponentInChildren<PlayerMotor>();
        playerCollision = GetComponentInChildren<PlayerCollisionController>();
        playerInput = GetComponent<PlayerInputController>();
        playerInput.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomMovement.SetIntensity(DeepFryLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlayer()
    {
        animator.SetBool("Swimming", true);
        playerInput.enabled = true;
    }

    public void StopPlayer()
    {
        // animator.SetBool("Swimming", false);
        playerInput.enabled = false;
        motor.SetInput(Vector2.zero);
        playerCollision.enabled = false;
    }

    public void OnHitEel()
    {
        DeepFryLevel++;
        lives--;

        randomMovement.SetIntensity(DeepFryLevel);
        PlayerDeepFied?.Invoke(DeepFryLevel);

        if (lives <= 0)
        {
            PlayerDied?.Invoke();
        }
    }

    public void OnHitEnd()
    {
        PlayerDied?.Invoke();
    }

    public void OnHitChip()
    {
        randomMovement.SetIntensity(0);
        PlayerWin?.Invoke();
    }
}
