using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [Header("Street variables")]
    public GameObject streetPrefab;
    public float STREET_LENGTH = 80f;
    public float speed = 10f;

    public static SpawnManager Instance { get; private set; }

    private Vector3 lastPosition;
    private List<GameObject> streetPrefabs;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;

        } // else

    } // Awake

    void Start() {
        lastPosition = transform.position;
        streetPrefabs = new List<GameObject>();
        InstantiateStreetSegments();
        InvokeRepeating("spawnStreet", 0.0f, (STREET_LENGTH * 3) / speed);

    } // Start

    void InstantiateStreetSegments() {
        for (int i = 0; i < 3; i++) {
            GameObject newStreet = Instantiate(streetPrefab, lastPosition, streetPrefab.transform.rotation);
            streetPrefabs.Add(newStreet);
            lastPosition += new Vector3(0, 0, STREET_LENGTH);

        } // for

        RemoveOldStreets();

    } // InstantiateStreetSegments

    void spawnStreet() {
        InstantiateStreetSegments();

    } // spawnStreets

    void RemoveOldStreets() {
        if (streetPrefabs.Count > 6) { 
            // Keep only the latest 6 segments
            GameObject oldStreet = streetPrefabs[0];
            streetPrefabs.RemoveAt(0);
            Destroy(oldStreet);

        } // if

    } // RemoveOldStreets

} // SpawnManager