using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {

    [HideInInspector]
    public GameObject player;

    public GameObject respawnObject;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");

        //Debug.Log("This is a message");
    }

    // Used to detect if this (the element that the script is assigned to) has collided with the player
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Player")
        {
            Debug.Log("ouch!");
            Destroy(player);
        }
    }

}

