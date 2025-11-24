using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
// This script keeps track of player help and dictates game over
// screen

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public int health = 3;
    private bool scoreAdded;
    
    public bool gameOverSoundPlayed = false;
    public TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject menuButton;
    
    void Start()
    {
        health = 3;
        scoreAdded = false;
        replayButton.SetActive(false);
        menuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // updates help
        if (health > 0)
        { 
            HealthText.text = "Health: " + health;
            gameOverText.text = "";
        }
        else
        {
            GameOverScreen();
        }
    }

    // Creates all the proponents of the game over screen
    public void GameOverScreen()
    {
        if (gameOverSoundPlayed == false)
        {     
            SoundManager.instance.PlaySound("GameOverSound");
            gameOverSoundPlayed = true;
        }
        
        GameObject.Find("GameController").GetComponent<GameStart>().gameOver = true;
        HealthText.text = "";
        gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " +
                            GameObject.Find("Score").GetComponent<ScoreUI>().finalScore;
        
        // sets game over buttons
        replayButton.SetActive(true);
        menuButton.SetActive(true);
        
        // add score to score board
        if(!scoreAdded)
        {
            GameObject.Find("Scoreboard").GetComponent<Scoreboard>()
                .AddEntry(GameObject.Find("Score").GetComponent<ScoreUI>().finalScore);
            scoreAdded = true;
        }
        
    }
    
    // Used for Replay? button on game over screen 
    public void ReplayLevel()
    {
        replayButton.SetActive(false);
        SceneManager.LoadScene("GameLevel");
    }
    
    // Used for Replay? button on game over screen 
    public void MainMenu()
    {
        menuButton.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
