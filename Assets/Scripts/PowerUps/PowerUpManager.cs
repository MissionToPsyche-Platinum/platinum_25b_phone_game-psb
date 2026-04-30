using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script stores all the power-up prefabs and spawning locations.
// Put the power up in the array and it will appear in one of the spawning
// locations

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpList;
    public Transform[] spawnLocations;
    public BoxCollider2D gameplayBounds; // game bounds for power ups
    public float padding = 0.5f;
    public float spawnTime = 2f;
    public float firstAppearance = 4f;
    public float rateOfSpawn = 20f;
    private int item;

    private void Start()
    {
        // repeats function call every certain seconds after an initial certain seconds
        InvokeRepeating(nameof(SpawnPowerUp),firstAppearance, rateOfSpawn);
    }
    
    private void SpawnPowerUp()
    {
        // Power-Up 0 : Trivia 60% chance
        // Get the power-up for 500 point score increase,
        // Answer the question right for an extra life
        // Power-Up 1 and 2 : Random 20% chance each
        // 1 : Slowdown, slows down player for a number of seconds
        // 2: Destroy Meteoroids, destroy all obstacles on screen

        item = Random.Range(0, 3);
        if (item != 0)
            item = Random.Range(1, 3);

        Bounds b = gameplayBounds.bounds;

        float x = Random.Range(b.min.x + padding, b.max.x - padding);
        float y = Random.Range(b.min.y + padding, b.max.y - padding);

        Vector3 spawnPos = new Vector3(x, y, 0);

        Instantiate(powerUpList[item], spawnPos, Quaternion.identity);

        SoundManager.instance.PlaySound("PowerUp");
    }
}
