using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    private Animator falling_Anim;
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        falling_Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falling_Anim.Play("Falling- On");
            StartCoroutine(Fall());
        }

    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
