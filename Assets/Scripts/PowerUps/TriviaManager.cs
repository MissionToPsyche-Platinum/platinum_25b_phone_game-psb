using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// This script stores all the questions and loads them onto the TriviaPanel.
//  Still need to add a way to clear buttons and pick a new question when
//  new power-ups are triggered.

public class TriviaManager: MonoBehaviour
{
    public List<Trivia> triviaBank;
    public GameObject[] choiceButtons;
    public int currentQuestion;
    public TextMeshProUGUI questionText;
    [SerializeField] private GameObject triviaPanel;

    private void Start()
    {
	    triviaPanel = GameObject.Find("Trivia Panel");
	    triviaPanel.SetActive(false);
    }

    // activates trivia panel and sets random question
    public void ActivateTrivia()
    {
	    triviaPanel.SetActive(true);
	    GetRandomQuestion();
    }

    // Gets random question from trivia bank
    private void GetRandomQuestion()
    {
        currentQuestion = Random.Range(0, triviaBank.Count);
        questionText.text = triviaBank[currentQuestion].question;
        SetChoices();
    }

   	// Adds answers to buttons based on question and picks correct answer.
   	// Use the inspector to set up questions and correct answers in TriviaManager
   	// GameObject
    private void SetChoices()
    {
        for (int button = 0; button < choiceButtons.Length; button++)
        {
            choiceButtons[button].GetComponent<Button>().interactable = true;
	        string choiceText = triviaBank[currentQuestion].choices[button];
            choiceButtons[button].GetComponentInChildren<TextMeshProUGUI>().text = choiceText;
            
            // Note that the correct options go from 1 to 4 due to how buttons work.
            // Keep it in mind when picking which button is the correct answer.
			if(triviaBank[currentQuestion].correctChoice == button+1)
			{
				choiceButtons[button].GetComponent<TriviaAnwser>().isCorrect = true;
			} else {
				choiceButtons[button].GetComponent<TriviaAnwser>().isCorrect = false;
			}

        }
    }

    // Returns the button with the correct answer
    public GameObject GetCorrectChoice()
    {
		GameObject choice = choiceButtons[0];

        for (int button = 0; button < choiceButtons.Length; button++)
        {
			if(triviaBank[currentQuestion].correctChoice == button+1)
			{
				choice =  choiceButtons[button];
			}
	        choiceButtons[button].GetComponent<Button>().interactable = false;
        }
		return choice;
    }
}
