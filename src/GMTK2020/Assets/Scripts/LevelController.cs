﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed = 2f;

    private bool running = false;

    private IEnumerable<LevelPanel> panels;

    private void Awake() {
        panels = GetComponentsInChildren<LevelPanel>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!running)
            return;

        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    public void StartLevel()
    {
        running = true;
    }

    public void Pause()
    {
        running = false;
    }

    public void SetDeepFryLevel(int deepFryLevel)
    {
        foreach(var panel in panels)
        {
            panel.SetDeepFryLevel(deepFryLevel);
        }
    }
}
