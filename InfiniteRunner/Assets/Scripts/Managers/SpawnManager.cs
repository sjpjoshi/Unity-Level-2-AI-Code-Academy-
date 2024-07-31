using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [Header("Street variables")]
    public GameObject streetPrefab;
    public float STREET_LENGTH = 80f;
    public float speed = 10f;

    [Header("Obstacles")]
    public GameObject obstacle;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    public static SpawnManager Instance { get; private set; }

    private Vector3 lastPosition;
    private List<GameObject> streetPrefabs;

    [Header("Player")]
    public Transform player; // Reference to the player's transform

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
        StartCoroutine("SpawnObstacles");

    } // Start

    void InstantiateStreetSegments() {
        for (int i = 0; i < 3; i++) {
            GameObject newStreet = Instantiate(streetPrefab, lastPosition, streetPrefab.transform.rotation);
            streetPrefabs.Add(newStreet);
            //PositionPlayerAbove(streetPrefabs[0]);
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

    IEnumerator SpawnObstacles() { 
        while(true) {
            Vector3 spawnPosition;

            if (Random.value < 0.5f) {
                spawnPosition = new Vector3(7.47f, 4.67999983f, player.position.z + 20);

            }
            else {
                spawnPosition = new Vector3(3.58999991f, 4.67999983f, player.position.z + 20);

            } // else

            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

        } // while

    } // SpawnObstacles
     

} // SpawnManager