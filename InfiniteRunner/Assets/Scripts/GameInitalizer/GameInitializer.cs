using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
    [SerializeField] 
    private SpawnManager spawnManager;
    
    [SerializeField] 
    private MoveForward moveForward;

    [SerializeField]
    private PlayerMovement playerMovement;

    void Awake() {
        moveForward.Initialize(spawnManager);
        playerMovement.Initialize(spawnManager);

    } // Awake

} // GameInitializer
