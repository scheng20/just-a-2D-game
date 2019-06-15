using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeRigid : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start()
    {
        rb.gravityScale = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 1;
        }
    }
}
