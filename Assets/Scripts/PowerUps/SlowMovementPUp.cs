using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script slows down Psyche spacecraft when random power-up is triggered 

public class SlowMovementPUp : MonoBehaviour
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
            // slows player down
            GameObject.Find("Psyche").GetComponent<PsycheMovement>().movementPowerUP = 10;
        }
    }
    
}
