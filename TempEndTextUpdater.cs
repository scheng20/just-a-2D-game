using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempEndTextUpdater : MonoBehaviour {

    public Text gameText;
    public Text gameText2;

    [HideInInspector]
    public int bumpCounter;

    // Use this for initialization
    void Start()
    {
        bumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bumpCounter = bumpCount.bump;

        //Display a message depending on how many times the player has died

        if (bumpCounter > 3)
        {
            gameText.text = "Or... play with the blocks... uh whatever floats your boat lol";
            gameText2.text = "";
        }
        
    }
}
