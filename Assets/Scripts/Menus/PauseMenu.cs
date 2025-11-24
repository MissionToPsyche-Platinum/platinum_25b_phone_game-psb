using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script dictates pausing and options in the pause menu

public class PauseMenu : MonoBehaviour
{
    private bool inPauseMenu = false;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject triviaPanel;
    public int health;

    private void Start()
    {
        triviaPanel = GameObject.Find("Trivia Panel");
        pausePanel = GameObject.Find("Pause Panel");
        pausePanel.SetActive(false);
        inPauseMenu = false;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            health = GameObject.Find("Health").GetComponent<HealthUI>().health;
            if (inPauseMenu == false && (health > 0))
                PauseGame();
            else
                ResumeGame();
        }
    }

    // Resumes game after paused
    public void ResumeGame()
    {
		//triviaPanel = GameObject.Find("Trivia Panel");
        if(ReferenceEquals(triviaPanel, null))
        {
            Time.timeScale = 1f;
        }
        pausePanel.SetActive(false);
        inPauseMenu = false;
    }

    // Pauses game
    private void PauseGame()
    {
        pausePanel.SetActive(true);
        inPauseMenu = true;
		Time.timeScale = 0f;
    }
    
    // causes game over
    public void ExitGame()
    {
        pausePanel.SetActive(false);
        inPauseMenu = false;
        GameObject.Find("Health").GetComponent<HealthUI>().health = 0;
		GameObject.Find("Health").GetComponent<HealthUI>().GameOverScreen();
    }
}
