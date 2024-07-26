using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    // variables
    private SpawnManager spawnManager;

    public void Initialize(SpawnManager manager) {
        spawnManager = manager;

    } // Initialize

    void Update() {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(transform.position.x, transform.position.y, spawnManager.STREET_LENGTH * 3),
            Time.deltaTime * spawnManager.speed

        ); // Vector3.MoveTowards

        if (transform.position.z >= spawnManager.STREET_LENGTH * 3) {
            Destroy(gameObject);

        } // if


    } // Update

} // MoveForward
