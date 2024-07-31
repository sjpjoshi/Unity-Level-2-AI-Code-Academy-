using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public static MenuManager Instance { get; private set; }

    public GameObject gameOverScreen; // Reference to the game over screen
    private bool isGameOver = false;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;

        } // else

    } // Awake

    void Start() {
        gameOverScreen.SetActive(false); // Hide the game over screen at the start

    } // Start

    public void GameOver() {
        isGameOver = true;
        gameOverScreen.SetActive(true); // Show the game over screen

    } // GameOver

    public bool IsGameOver() {
        return isGameOver;

    } // IsGameOver

    public void restartLevel() {
        isGameOver = false;
        gameOverScreen.SetActive(false); // Hide the game over screen
        SceneManager.LoadScene("SampleScene");

    } // restartLevel

} // MenuManager
