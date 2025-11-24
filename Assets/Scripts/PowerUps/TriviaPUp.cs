using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script  handles the trivia power-up itself. Specifically , it handles
// its destruction and interaction with psyche

public class TriviaPUp : MonoBehaviour
{
    private float lifespan = 12f;
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
    private void OnTriggerEnter2D(Collider2D objectCollider)
    {
        if (objectCollider.CompareTag("Psyche"))
        {
            Destroy(gameObject);
            // Actually adds 1000 points but the final number is multiplied by 5
            GameObject.Find("Score").GetComponent<ScoreUI>().score+=200;
            GameObject.Find("TriviaManager").GetComponent<TriviaManager>().ActivateTrivia();
            //pauses most operations in-game except UI
            Time.timeScale = 0f;
            
        }
    }
    
}
