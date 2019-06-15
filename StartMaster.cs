using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaster : MonoBehaviour
{
    public static bool playGame;

	// Use this for initialization
	void Start ()
    {
        playGame = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // [X] to start
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<AudioSource>().Play();

            playGame = true;
        }

        // [Esc] to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
