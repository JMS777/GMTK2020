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
        OnPlayerDeepFied(0);
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

        switch (deepFryLevel)
        {
            case 0:
                MusicManager.Instance.FadeIn(MusicTrackIdentifier.DeepFry1);
                break;
            case 1:
                MusicManager.Instance.FadeOut(MusicTrackIdentifier.DeepFry1);
                MusicManager.Instance.FadeIn(MusicTrackIdentifier.DeepFry2);
                break;
            case 2:
                MusicManager.Instance.FadeOut(MusicTrackIdentifier.DeepFry2);
                MusicManager.Instance.FadeIn(MusicTrackIdentifier.DeepFry3);
                break;
            case 3:
                MusicManager.Instance.FadeOut(MusicTrackIdentifier.DeepFry3);
                MusicManager.Instance.FadeIn(MusicTrackIdentifier.DeepFry4);
                break;
        }

        level.SetDeepFryLevel(deepFryLevel);
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
