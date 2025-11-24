using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script controls movement of the Psyche spacecraft

public class PsycheMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public Vector2 direction;
    public Vector3 mousePosition;
    public Animator animator;
    
    //speeds for run/walk
	
    private float moveSpeed;
	private float defaultWalkSpeed = 6f;
    private float defaultRunSpeed = 15f;
    public float walkSpeed;
    public float runSpeed;
    public int movementPowerUP = 0;
	private float movementPowerUpTimer = 0;

    public float forceMultiplier = 1;
	public Vector2 oldPosition = Vector2.zero;

	public float topy;
	public float bottomY;
    public float leftX;
    public float rightX;

    // Start is called before the first frame update
    private void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
		BoundaryClamping();
		float verticalPos = Input.GetAxis("Vertical");
		float horizontalPos = Input.GetAxis("Horizontal");
		
		// hold shift to walk
		if (Input.GetKey(KeyCode.LeftShift))
		{
			moveSpeed = walkSpeed;
		} 
		else 
		{
			moveSpeed = runSpeed;
		}

		// movementPowerUp
		if(movementPowerUP > 0)
		{
			walkSpeed = defaultWalkSpeed * 0.1f;
			runSpeed = defaultRunSpeed * 0.1f;
		}
		else
		{
			walkSpeed = defaultWalkSpeed;
			runSpeed = defaultRunSpeed;
		}

		movementPowerUpTimer += Time.deltaTime;
		if(movementPowerUpTimer >= 1)
		{
			movementPowerUP--;
			movementPowerUpTimer = 0;
		}
		
		movement = new Vector2(horizontalPos,verticalPos) * moveSpeed;
		oldPosition = transform.position;
    }
    
    // FixedUpdate is called every physics detection step  
    private void FixedUpdate()
    {
		if((Input.GetKey(KeyCode.W) ||
			Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.D) ||
			Input.GetKey(KeyCode.UpArrow) ||
			Input.GetKey(KeyCode.LeftArrow) ||
			Input.GetKey(KeyCode.DownArrow) ||
			Input.GetKey(KeyCode.RightArrow)
			))
			MovePsyche(movement);
    }
    
   // Constrains Psyche prefab to screen boundaries 
   private void BoundaryClamping()
   {
		// Clamps player object to size x by y screen
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftX + 1.3f, rightX - 1.3f),
		Mathf.Clamp(transform.position.y, bottomY + 0.5f, topy - 0.4f), transform.position.z);
   }

    // Type of movement Psyche spacecraft will have
    public void MovePsyche(Vector2 direction)
    {
		// sets parameters that determine animation to use
		if (animator != null)
		{
			animator.SetFloat("verticalDistance", direction.y * Time.deltaTime);
			animator.SetFloat("horizontalDistance", direction.x * Time.deltaTime);
		}
		Vector2 position = (Vector2)transform.position + (direction * Time.deltaTime);
		rb.MovePosition(position);
    }

    // Applies pushback to player on collision, we can 
    // get rid of the entire function if the pushback 
    // is not needed
    // && enemyCollider.gameObject.GetComponent<Asteroid>().health == 1
    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
	    if (enemyCollider.CompareTag("Asteroid"))
	    {
            // asteroid collision consumed
            enemyCollider.gameObject.GetComponent<Asteroid>().health = 0;
		    // Reduces player's life
        	GameObject.Find("Health").GetComponent<HealthUI>().health--;
            rb.MovePosition(rb.transform.position - new Vector3(0, 0.5f, 0));
			Debug.Log("Hit by asteroid");
	    }
    }
}
