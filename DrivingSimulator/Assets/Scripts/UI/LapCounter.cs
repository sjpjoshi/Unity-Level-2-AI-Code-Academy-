using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour {

    // variables
    public TextMeshProUGUI LapText;
    private int lapCount = 1;

    private void Awake() {
        LapText = GetComponent<TextMeshProUGUI>();

    } // Awake

    void Start() {
        LapMarker.OnLapMarkerTouched += IncrementLapCount;

    } // Update

    void IncrementLapCount() {
        lapCount++;
        LapText.text = "Lap: " + lapCount;

    } // IncrementLapCount

    private void OnDestroy() {
        LapMarker.OnLapMarkerTouched -= IncrementLapCount;

    } // OnDestroy

} // LapCounter
