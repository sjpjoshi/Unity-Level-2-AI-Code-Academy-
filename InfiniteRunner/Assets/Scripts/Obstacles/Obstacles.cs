using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    public float lifetime = 5f; // Adjust this value to control how long the obstacle stays in the scene

    void Start() {
        Destroy(gameObject, lifetime); // Destroy the obstacle after 'lifetime' seconds

    } // Start

    void Update() {
        transform.position += new Vector3(0, 0, -10f * Time.deltaTime);

    } // Update

} // Obstacles
