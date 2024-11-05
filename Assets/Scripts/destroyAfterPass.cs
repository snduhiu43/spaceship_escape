using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterPass : MonoBehaviour
{
    private GameObject player;
    public float destroyDistance = 10f;
	
	// Start is called before the first frame update
    void Start()
    {
        // Find the player in the scene
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has passed the object by a certain distance
        if (player != null && transform.position.z > player.transform.position.z + destroyDistance)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " destroyed after player passed.");
        }
    }
}
