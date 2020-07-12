using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer sr;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetDeepFryLevel(int level)
    {
        sr.sprite = sprites[level];
    }
}
