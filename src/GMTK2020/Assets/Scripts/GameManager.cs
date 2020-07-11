using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startDelay = 3f;

    private LevelController level;
    private PlayerController player;

    private HudController hud;

    private void Awake()
    {
        level = FindObjectOfType<LevelController>();
        player = FindObjectOfType<PlayerController>();
        hud = FindObjectOfType<HudController>();


        player.PlayerDied += OnPlayerDeath;
        player.PlayerWin += OnPlayerWin;
        player.PlayerDeepFied += OnPlayerDeepFied;
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
        player.StartPlayer();
    }

    private void OnPlayerDeepFied(int deepFryLevel)
    {
        hud.SetDeepFryLevel(deepFryLevel);
    }

    private void OnPlayerDeath()
    {
        level.Pause();
        player.StopPlayer();

        GameOver();
    }

    private void OnPlayerWin()
    {
        level.Pause();
        player.StopPlayer();

        Win();
    }

    private void Win()
    {
        hud.Win();
    }

    private void GameOver()
    {
        hud.Lose();
    }

    public void MainMenu()
    {
        LevelLoader.Instance.LoadLevel((int)LevelLoader.Levels.Menu);
    }
}
