using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpCount : MonoBehaviour
{
    public static int bump;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Decoration")
        {
            bump = bump + 1;
        }
    }
}
