using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    public float distance;
    bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if(isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if(hit.transform != null)
            {
                if(hit.transform.CompareTag("Player"))
                {
                    rb.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }
}
