using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class Drive : MonoBehaviour {

    // Car Variables
    public float speed = 1;
    private float acceleration;
    private Rigidbody rb;
   
    void Awake() {
        rb = GetComponent<Rigidbody>();
      
    } // Start

    private void Start() {
        acceleration = 0.02f;

    } // Start

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            speed = speed + (acceleration * Time.deltaTime);
            rb.AddForce(transform.forward * speed * rb.mass, ForceMode.Impulse); // move foward with velocity

        } // if

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ) {
            speed = speed - (acceleration * Time.deltaTime);
            rb.AddForce(transform.forward * speed * -rb.mass, ForceMode.Impulse); // move foward with velocity

        } // if

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) ) {
            rb.transform.Rotate(0.0f, 0.4f, 0.0f);

        } // if

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ) {
            rb.transform.Rotate(0.0f, -0.4f, 0,0f);

        }// if

    } // Update

} // Drive
