using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Variables
    [Header("Camera Variables")]
    public float speed = 10f;
    public GameObject player;

    private Rigidbody rb;
    private Vector3 offset;

    void Awake() {
        rb = GetComponent<Rigidbody>();

    } // Awake

    private void Start() {
        offset = transform.position - player.transform.position;

    } // Start

    // Update is called once per frame
    void Update() {
        transform.position = player.transform.position + offset;

    } // Update

} // CameraController
