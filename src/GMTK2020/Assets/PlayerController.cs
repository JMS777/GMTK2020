using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action PlayerDied;

    public int lives = 3;
    public int DeepFryLevel { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHitEel()
    {
        DeepFryLevel++;
        lives--;

        if (lives <= 0)
        {
            PlayerDied?.Invoke();
        }
    }
}
