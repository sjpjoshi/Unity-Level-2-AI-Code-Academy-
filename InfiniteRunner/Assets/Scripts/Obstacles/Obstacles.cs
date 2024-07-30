using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    void Update() {
        transform.position += new Vector3(0, 0, -10f * Time.deltaTime);

    } // Update

} // Obstacles
