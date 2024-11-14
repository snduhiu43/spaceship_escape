using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject player;
	public GameManager gameManager;
	public GameObject[] spacePrefabs;
    public float spawnDistance = 15;       // Distance in front of the player to spawn objects
    public float spawnInterval = 2f; 	// Time interval between objects spawn
	public float startDelay = 2f; 		// Period to delay before the first spawn
    private float fixedY = 5f;              // Fixed y position for spawns
	
	// Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void StartSpawning()
    {
        InvokeRepeating("SpawnSpacePrefabs", startDelay, spawnInterval);
    }
	
	public void StopSpawning()
    {
        CancelInvoke("SpawnSpacePrefabs");
    }
	
	void SpawnSpacePrefabs()
    {
        // Random x position within the range
        float randomX = Random.Range(-1, 4);

        // Calculate spawn position in front of the player
        Vector3 spawnPos = new Vector3(randomX, fixedY, player.transform.position.z - spawnDistance);
		
		int spaceObjectsIndex = Random.Range(0, spacePrefabs.Length);

        // Instantiate the obstacle prefab at the spawn position
        Instantiate(spacePrefabs[spaceObjectsIndex], spawnPos, spacePrefabs[spaceObjectsIndex].transform.rotation);
		
		//Debug.Log("Prefab spawned at: " + spawnPos);
	}
}
