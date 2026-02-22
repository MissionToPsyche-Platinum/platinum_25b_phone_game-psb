using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Animator animator;
    public bool collision = false;
    float bottomY;
    float leftX;
    float rightX;
    public float health = 1;

    private SpawnAsteroids spawnAsteroids;
    private bool isReleased = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnAsteroids = GameObject.Find("GameController").GetComponent<SpawnAsteroids>();
    }

    public void ResetAsteroid(Vector3 position, Vector2 scale, Vector2 velocity)
    {
        CancelInvoke(nameof(ReleaseToPool));
        // Reset position, scale, velocity
        transform.position = position;
        transform.localScale = scale;
        rb.linearVelocity = velocity;

        // Reset state
        health = 1;
        isReleased = false;
        collision = false;

        // Reset animator
        animator.SetBool("destroyed", false);

        // Reset bounds from GameStart
        GameStart gameStart = GameObject.Find("GameController").GetComponent<GameStart>();
        bottomY = gameStart.lowerLeftXY.y;
        leftX = gameStart.lowerLeftXY.x;
        rightX = gameStart.lowerRightXY.x;
    }

    public void ReleaseToPool()
    {
        if (isReleased) return;
        isReleased = true;
        spawnAsteroids.ReleaseAsteroid(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < bottomY - 2 || transform.position.x < leftX - 2 || transform.position.x > rightX + 2)
        {
            ReleaseToPool();
        }
    }
    
    // plays sound and sets asteroid animation 
    // variable
    public void DestroyAsteroid()
    {
        if (animator.GetBool("destroyed")) return;
        SoundManager.instance.PlaySound("CollisionSound");
        collision = true;
        animator.SetBool("destroyed", collision);
        collision = false;
    }
    
    private void OnTriggerEnter2D(Collider2D objectCollider)
    {
        // Destroy is now triggered by PsycheMovement only
        // to avoid double destroy from execution order differences
    }
}
