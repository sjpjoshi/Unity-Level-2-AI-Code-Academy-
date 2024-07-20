using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Drive : MonoBehaviour {

    // Car Variables
    public float speed = 1;
    private Rigidbody rb;
   
    void Awake() {
        rb = GetComponent<Rigidbody>();
      
    } // Start

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange); // move foward with velocity

        } // if

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(transform.forward * speed * -1, ForceMode.VelocityChange); // move foward with velocity

        } // if

    } // Update

} // Drive
