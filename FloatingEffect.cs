using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    float originalY;

    public float floatStrength = 1; // You can change this in the Unity Editor to 
                                    // change the range of y positions that are possible.

    // Use this for initialization
    void Start ()
    {
        this.originalY = this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x,
           originalY + ((float)Math.Sin(Time.time) * floatStrength),
           transform.position.z);
    }
}
