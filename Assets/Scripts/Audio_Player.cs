using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour
{
    public AudioClip audioClip; // Reference to the audio clip
    private AudioSource audioSource; // Reference to the audio source

    void Start()
    {
        // Get the AudioSource component attached to the same game object
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip to play
        audioSource.clip = audioClip;
    }

    void Update()
    {
        // Check if the spacebar key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the audio clip
            audioSource.Play();
        }
    }
}
