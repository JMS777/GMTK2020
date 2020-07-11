using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomMovement : MonoBehaviour
{
    public float intensity = 1f;
    public float currentIntensity = 0f;

    public float[] intensityLevels;

    public float seedX = 0f;
    public float seedY = 10f;

    public float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.localPosition;
        newPos.x = (Mathf.PerlinNoise(Time.time * speed, seedX) - .5f) * currentIntensity;
        newPos.y = (Mathf.PerlinNoise(Time.time * speed, seedY) - .5f) * currentIntensity;

        transform.localPosition = newPos;
    }

    public void SetIntensity(int deepFryLevel)
    {
        StartCoroutine(SmoothIntensity(deepFryLevel));
    }

    private IEnumerator SmoothIntensity(int deepFryLevel)
    {
        float t = 0;

        deepFryLevel = Mathf.Clamp(deepFryLevel, 0, intensityLevels.Length -1);

        while (t < 1)
        {
            t += Time.deltaTime / 2f;
            currentIntensity = Mathf.Lerp(currentIntensity, intensityLevels[deepFryLevel], t);
            yield return null;
        }
        
        currentIntensity = intensityLevels[deepFryLevel];
    }
}
