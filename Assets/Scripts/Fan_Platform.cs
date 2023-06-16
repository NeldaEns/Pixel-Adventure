using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Platform : MonoBehaviour
{
    private Animator fan_Anim;

    private void Start()
    {
        fan_Anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fan_Anim.Play("Fan_On");
        }

    }
}
