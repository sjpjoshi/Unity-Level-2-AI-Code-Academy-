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
            rb.AddForce(transform.forward * speed * rb.mass, ForceMode.Impulse); // move foward with velocity

        } // if

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(transform.forward * speed * -rb.mass, ForceMode.Impulse); // move foward with velocity

        } // if

        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.transform.Rotate(0.0f, 0.4f, 0.0f);

        } // if

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.transform.Rotate(0.0f, -0.4f, 0,0f);

        }// if

    } // Update

} // Drive
