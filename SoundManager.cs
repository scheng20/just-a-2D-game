using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{ 
    //Declare audio clips
    public AudioClip Win;
    public AudioClip Death;
    public AudioSource audioC;

    string playerState;

    // Use this for initialization
    void Start ()
    {
        audioC = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (playerState.Equals("dead"))
        {
            // Play the death sound
            audioC.PlayOneShot(Death, 0.7F);
        }
        else if (playerState.Equals("win"))
        {
            //Play the achievement sound
            audioC.PlayOneShot(Win, 0.7F);
        }
        

    }
}
