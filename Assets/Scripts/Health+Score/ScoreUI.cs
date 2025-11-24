using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// This script keeps track of the player score

public class ScoreUI : MonoBehaviour
{
    public float score = 0;
    public int finalScore = 0;
    public float scoreRate = 1f;
    public TextMeshProUGUI scoreText;

    private void Update()
    {   

        if(GameObject.Find("GameController").GetComponent<GameStart>().gameOver == true)
        {
            scoreText.text = "";
        }
        else
        {
            // Adds 5 to score every in-game second, changed to
           // from original implementation to allow points from power-up
            score += Time.deltaTime * scoreRate;
            finalScore = (int)score * 5 ;
            scoreText.text = "SCORE: " + finalScore;
        }
    }
}
