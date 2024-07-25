using UnityEngine;

public class CarEngineSound : MonoBehaviour {
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

    } // Awake

    void Start() {
        PlayEngineSound();

    } // Start

    void PlayEngineSound() {
        if (audioSource != null && audioSource.clip != null) {
            audioSource.Play();

        } else {
            Debug.LogWarning("AudioSource or AudioClip is missing.");

        }

    } // PlayEngineSound

} // CarEngineSound
