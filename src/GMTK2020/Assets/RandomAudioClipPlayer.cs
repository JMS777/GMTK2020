using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClipPlayer : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource audioSource;

    public float delay = .5f;
    public float currentTime = 0f;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > delay)
        {
            Debug.Log("play");
            currentTime = 0;

            audioSource.Stop();
            audioSource.clip = clips[Random.Range(0, clips.Length)];

            audioSource.Play();
        }
    }
}
