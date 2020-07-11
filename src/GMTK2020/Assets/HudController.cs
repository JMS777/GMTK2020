using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public TMP_Text text;
    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeepFryLevel(int lives)
    {
        text.text = $"DEEP FRY LEVEL: {lives}";
    }

    public void Win()
    {
        win.SetActive(true);
    }

    public void Lose()
    {
        lose.SetActive(true);
    }
}
