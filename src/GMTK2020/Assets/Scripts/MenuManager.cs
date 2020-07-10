using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.FadeIn(MusicTrackIdentifier.MainTrack);
    }

    public void Play()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
}
