using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
    [SerializeField] 
    private SpawnManager spawnManager;
    [SerializeField] 
    private MoveForward moveForward;

    void Awake() {
        moveForward.Initialize(spawnManager);

    } // Awake

} // GameInitializer
