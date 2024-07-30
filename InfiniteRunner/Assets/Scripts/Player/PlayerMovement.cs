using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // Animator
    Animator anim;

    // singleton
    private SpawnManager spawnManager;

    public void Initialize(SpawnManager manager) {
        spawnManager = manager;

    } // Initialize

    private void Awake() {
        anim = GetComponent<Animator>();

    } // Awake

    void Start() {
        // Initialize the player's position on the right lane
        targetLaneX = transform.position.x;

    } // Start

    void Update() {

        // Jumping 
        velocityY += gravity * Time.deltaTime;

        if (isGrounded() && velocityY < 0) {
            velocityY = 0;
            anim.SetBool("isJumping", false);

        } // if

        if (transform.position.y < 4.633) {
            transform.position = new Vector3(transform.position.x, 4.633f, transform.position.z);

        } // if

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            velocityY = 10;
            anim.SetBool("isJumping", true);

        } // if

        // Swapping Lanes
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

        transform.position += new Vector3(0, 0, spawnManager.speed * Time.deltaTime);

    } // Update

    bool isGrounded() {
        return transform.position.y <= 4.633f;

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