using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // lane change variables
    float leftLaneX = 3.299988f;
    float rightLaneX = 7.299988f;

    // current lane position
    private float targetLaneX;

    // jump variables
    float velocityY;
    float gravity = -9.8f;

    // singleton
    private SpawnManager spawnManager;

    public void Initialize(SpawnManager manager) {
        spawnManager = manager;

    } // Initialize

    void Start() {
        // Initialize the player's position on the right lane
        targetLaneX = transform.position.x;

    } // Start

    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow) && targetLaneX != leftLaneX) {
            targetLaneX = leftLaneX;
            StopAllCoroutines();
            StartCoroutine(swapLane(targetLaneX, 0.1f));

        } // if

        if (Input.GetKey(KeyCode.RightArrow) && targetLaneX != rightLaneX) {
            targetLaneX = rightLaneX;
            StopAllCoroutines();
            StartCoroutine(swapLane(targetLaneX, 0.1f));

        } // if

        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(transform.position.x, transform.position.y, spawnManager.STREET_LENGTH * 3),
            Time.deltaTime * spawnManager.speed

        ); // Vector3.MoveTowards


    } // Update

    bool isGrounded() {
        return transform.position.y <= 0;

    } // isGrounded

    IEnumerator swapLane(float newPosition, float time) {
        float elapsedTime = 0;
        float startingX = transform.position.x;

        while (elapsedTime < time) {
            transform.position = new Vector3(Mathf.Lerp(startingX, newPosition, (elapsedTime / time)), transform.position.y, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } // while

        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

    }  // swapLane

} // PlayerMovement