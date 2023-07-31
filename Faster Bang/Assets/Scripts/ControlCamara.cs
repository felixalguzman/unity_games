using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Jugador");
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        
      
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }


}
