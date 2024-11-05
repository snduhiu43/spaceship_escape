using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalSpeed = 10f;
	public float speedIncrease = 5f;
	public float horizontalInput;
	
	public AudioClip fuelCollectSound;
    public AudioClip collisionSound;
	private AudioSource playerAudio;
	
    public ParticleSystem collisionEffect;
	
	private GameManager gameManager;
	private Rigidbody playerRb;
	
	// Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		playerAudio = GetComponent<AudioSource>();
		
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (gameManager.isGameActive) 
	   {
		   //get hirizontal inputs from user
			horizontalInput = Input.GetAxis("Horizontal");
	   
		   //move spaceship constantly forward
		   transform.Translate(Vector3.back * Time.deltaTime * horizontalSpeed);
		   
		   // Move spaceship left or right based on horizontal input
		   transform.Rotate(Vector3.up * horizontalSpeed * Time.deltaTime * horizontalInput);
	   }
    }
	
	public void IncreaseSpeed()
    {
        speed += speedIncrease; // Increase player speed
    }
	
	void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a fuel object
        if (other.CompareTag("Fuel") && gameManager.isGameActive)
        {
            // Destroy the fuel object on collision
            playerAudio.PlayOneShot(fuelCollectSound, 0.8f);
			Destroy(other.gameObject);
            gameManager.IncreaseScore(5);
        }
        else if (other.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(collisionSound, 0.8f);
            Instantiate(collisionEffect, transform.position, collisionEffect.transform.rotation);
            gameManager.GameOver();
            //Destroy(gameObject);
        }
    }
}