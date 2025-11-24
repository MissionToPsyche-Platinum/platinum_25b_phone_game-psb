using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script handles asteroid spawning

public class SpawnAsteroids : MonoBehaviour
{

    public GameObject asteroidPrefab;
    private float asteroidSpawnTimeMin = 3f; // originally 4
    private float asteroidSpawnTimeMax = 6f; // originally 8
    public float lastAsteroidTime = -100f;
    private float newTime = -100f;
    private float astSize = 0; 
    private float speedBoost = 0f;
    //private float w = Screen.width;
    //private float h = Screen.height;
    

    public float leftSide;
    public float rightSide;

    public List<GameObject> asteroids = new List<GameObject>();
 
    // Update is called once per frame
    void Update()
    {
        // Launch asteroids
        if (Time.time - lastAsteroidTime > Random.Range(asteroidSpawnTimeMin, asteroidSpawnTimeMax))
        {
            lastAsteroidTime = Time.time;
            // create instance and set position and velocity
            GameObject asteroid = Instantiate(asteroidPrefab);
            astSize = Random.Range(.015f, .032f); // originally .01 to .03
            asteroid.transform.localScale = new Vector2(astSize, astSize);
            asteroid.transform.position = new Vector3(Random.Range(leftSide, rightSide), transform.position.y + 6, 0);
            asteroid.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(Random.Range(-4f, 4f), Random.Range(-8f - speedBoost, -.3f), 0).normalized * Random.Range(.1f, 10f);
            asteroids.Add(asteroid);	
        }


        //difficulty increases over time
        if (Time.time - newTime > 1f)
        {
	        newTime = Time.time;
	        asteroidSpawnTimeMin = asteroidSpawnTimeMin - .025f;
	        asteroidSpawnTimeMax = asteroidSpawnTimeMax - .025f; 
	        speedBoost = speedBoost - .05f;

	        if (asteroidSpawnTimeMin < .3f)
	        {
	        	asteroidSpawnTimeMin = .3f;
	        }

	        if (asteroidSpawnTimeMax < 1f)
	        {
	        	asteroidSpawnTimeMax = 1f;
	        }

	        if (speedBoost < -4f)
	        {
	        	speedBoost = -4f;
	        }
   		}


    }
}
