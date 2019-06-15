using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    // Reference to the deathParticles Prefab Game Object
    public GameObject deathParticlesPrefab;

    // Boolean used to detect whether or not player has completed level
    public static bool LevelComplete;

    // Boolean used to make sure the win sound only plays ONCE
    [HideInInspector]
    public bool playedSound;


    // Initialization
    void Start()
    {
        LevelComplete = false;
        playedSound = false;
    }

    public int fallBoundary = -10;

    void Update()
    {
        // If the player goes offscreen on left bottom
        if (transform.position.x <= -12 && transform.position.y < 0)
        {
            //Teleport the player to right top
           transform.position = new Vector2(13, 5);
        }

        // If the player goes offscreen on right bottom
        if (transform.position.x >= 12 && transform.position.y < 0)
        {
            //Teleport the player to left top
            transform.position = new Vector2(-13, 5);
        }

        // If the player falls off screen
        if (transform.position.y <= fallBoundary)
        {
            KillPlayer();
        }

    }

    void KillPlayer()
    {
        GameMasterTeleport.KillPlayer(this);
        GameMasterTeleport.IncreaseDeath();
    }

    // Used to detect if the element (player) has collided with anything
    void OnCollisionEnter2D(Collision2D col)
    {
        // If the player has collided with a deathzone do this:
        if (col.gameObject.tag == "Death")
        {
            // Instantiate death particles at the point of collision 
            ContactPoint2D contact = col.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject clone = (GameObject)Instantiate(deathParticlesPrefab, pos, rot);

            // Delete these death particles 3 seconds later
            Destroy(clone, 3f);

            // Kill the actual player
            KillPlayer();

        }

        //If the player has collided with the end key do this:
        if (col.gameObject.tag == "End")
        {
            if (playedSound == false)
            {
                //Play the win sound ONCE
                GetComponent<AudioSource>().Play();
                playedSound = true;
            }

            //Set the level as complete (this variable is used by the level changer to see if the player has completed the level)
            LevelComplete = true;

        }
    
}

}
