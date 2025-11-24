using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// This script is added to each button and acts
// when the button is clicked. It checks if
// the correct answer was picked and resumes
// the dodging part of the game

public class TriviaAnwser : MonoBehaviour
{
    public bool isCorrect = false;
    public GameObject correctChoice;
    
    public void CheckAnswer()
    {
        if (isCorrect)
        {
            SoundManager.instance.PlaySound("CorrectSound");
            // Adds extra life to player if correct.
            GameObject.Find("Health").GetComponent<HealthUI>().health++;

        }
        else
        {
            SoundManager.instance.PlaySound("IncorrectSound");	
        } 
        
        // gets the button that has the correct answer and turns it green for
        // a second
        correctChoice = GameObject.Find("TriviaManager").GetComponent<TriviaManager>().GetCorrectChoice();
		// correctChoice.GetComponent<Button>().interactable = false;
        correctChoice.GetComponent<Image>().color = Color.green;
        // Keeps the Question of screen for a second  and then resumes shoot em up
        // portion.
        StartCoroutine(ExitTrivia()); 
    }

    // exits the trivia panel when question is
    // answered
        private IEnumerator ExitTrivia()
	{
        yield return new WaitForSecondsRealtime(1);
        GameObject.Find("Trivia Panel").SetActive(false);
        Time.timeScale = 1f;
        correctChoice.GetComponent<Image>().color = Color.white;
        GameObject.Find("Psyche").GetComponent<PsycheMovement>().movement = Vector2.zero;
	}
}
