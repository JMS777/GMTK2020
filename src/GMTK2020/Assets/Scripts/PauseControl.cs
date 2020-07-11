using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseControl : Singleton<PauseControl>
{
    public GameObject PauseMenu;

    public bool IsPaused { get; private set; }

    private void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !LevelLoader.Instance.LoadingLevel)
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        IsPaused = false;
        PauseMenu.SetActive(false);
    }
}
