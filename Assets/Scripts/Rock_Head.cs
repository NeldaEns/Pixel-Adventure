using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Head : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    public Transform up;
    public Transform down;
    bool chop;
    private Animator rock_anim;

    private void Start()
    {
        rock_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.position.y >= up.position.y)
        {
            chop = true;
            rock_anim.Play("Blink");
        }

        if(transform.position.y <= down.position.y)
        {
            chop = false;
        }

        if(chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position, downspeed * Time.deltaTime);
        }
        
        if(!chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, up.position, upspeed * Time.deltaTime);
        }
    }
}
