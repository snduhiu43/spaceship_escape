using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
	
	// Start is called before the first frame update
    void Start()
    {
        // Find the player GameObject by name if it hasn’t been assigned
		if (player == null) {
            player = GameObject.Find("Player");
        }
		
		// Set the offset for the camera relative to the player
		offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Check if the player object exists before updating the camera position
        if (player != null) {
            transform.position = player.transform.position + offset;
        }
		else {
            Debug.LogWarning("Player GameObject is not assigned or has been destroyed.");
        }
    }
}
