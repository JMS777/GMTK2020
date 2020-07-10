using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelLoader : Singleton<LevelLoader>
{
    public Animator transition;
    public float transitionTime = 1f;

    public bool LoadingLevel { get; private set; }

    public enum Levels
    {
        Splash,
        Menu,
        Game
    }

    public void LoadNextLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    public void LoadLevel(int sceneBuildIndex)
    {
        StartCoroutine(LoadLevelRoutine(sceneBuildIndex));
    }

    IEnumerator LoadLevelRoutine(int sceneBuildIndex)
    {
        LoadingLevel = true;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        LoadingLevel = false;
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
