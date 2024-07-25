using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarMovementSound : MonoBehaviour {

    private AudioSource audioSource;
    private Rigidbody rb;
    public float speedThreshold = 0.1f;  // Threshold to consider the car is moving

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        if (audioSource == null) {
            Debug.LogWarning("AudioSource component is missing.");

        } // if

        if (rb == null) {
            Debug.LogWarning("Rigidbody component is missing.");

        } // if

    } // Awake

    private void Update() {
        if (rb != null && audioSource != null) {
            float speed = rb.velocity.magnitude;

            if (speed > speedThreshold && !audioSource.isPlaying) {
                audioSource.Play();

            } else if (speed <= speedThreshold && audioSource.isPlaying) {
                audioSource.Pause();

            } // else if

        } // if

    } // Update

} // CarMovementSound
