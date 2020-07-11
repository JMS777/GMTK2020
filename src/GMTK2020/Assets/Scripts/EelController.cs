using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelController : MonoBehaviour
{
    public float intensity = 1f;
    // public float currentIntensity = 0f;

    // public float[] intensityLevels;

    private Vector2 startPosition;

    public float seed = 0f;
    // public float seedY = 10f;

    public float speed = 1.5f;

    private void Start()
    {
        startPosition = transform.localPosition;
        // currentIntensity = intensityLevels[0];
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = startPosition;
        newPos.x = newPos.x + (Mathf.PerlinNoise(Time.time * speed, seed) - .5f) * intensity;

        transform.localPosition = newPos;
    }

    // public void SetIntensity(int deepFryLevel)
    // {
    //     currentIntensity = intensityLevels[deepFryLevel];
    // }
}
