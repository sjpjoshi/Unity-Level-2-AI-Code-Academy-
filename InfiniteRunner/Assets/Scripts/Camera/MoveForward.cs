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
        transform.position += new Vector3(0, 0, spawnManager.speed * Time.deltaTime);

    } // Update

} // MoveForward
