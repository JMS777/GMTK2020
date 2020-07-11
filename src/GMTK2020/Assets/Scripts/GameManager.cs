using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startDelay = 3f;

    private LevelController level;
    private PlayerController player;

    private void Awake()
    {
        level = FindObjectOfType<LevelController>();
        player = FindObjectOfType<PlayerController>();

        player.GetComponent<PlayerInputController>().enabled = false;

        player.PlayerDied += OnPlayerDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(startDelay);

        StartGame();
    }

    private void StartGame()
    {
        level.StartLevel();
        player.GetComponent<PlayerInputController>().enabled = true;
    }

    private void OnPlayerDeath()
    {
        level.Pause();
        player.GetComponent<PlayerInputController>().enabled = false;
    }
}
