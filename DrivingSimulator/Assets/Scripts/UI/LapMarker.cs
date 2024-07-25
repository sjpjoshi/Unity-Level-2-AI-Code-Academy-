using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapMarker : MonoBehaviour {

    public static Action OnLapMarkerTouched;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            OnLapMarkerTouched();

        }  // if

    } // OnTriggerEnter

} // LapMarker
