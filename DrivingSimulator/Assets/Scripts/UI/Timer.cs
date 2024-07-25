using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour {

    // private
    private TextMeshProUGUI time;

    void Awake() {
        time = GetComponent<TextMeshProUGUI>();

    } // Start

    void Update() {
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        time.text = timeSpan.ToString("mm\\:ss");

    } // Update

} // Timer
