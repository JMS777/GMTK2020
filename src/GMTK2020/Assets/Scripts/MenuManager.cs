using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
}
