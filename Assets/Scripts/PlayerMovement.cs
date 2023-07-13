﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float dirX;
    public float delayBeforeDoubleJump;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float fanForce = 26f;

    public enum MovementState
    {
        idle,
        running,
        jumping,
        falling,
    }

    public MovementState currentAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //if (IsGround() && !Input.GetButton("Jump"))
        //{
        //    GameController.ins.doubleJump = false;
        //}

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (IsGround() || GameController.ins.doubleJump)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        //        GameController.ins.doubleJump = !GameController.ins.doubleJump;
        //    }

        //    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //    }
        //}
        UpdateAnimationState();
    }
    public void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector3.down, .1f, jumpableGround);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, fanForce);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            DataManager.ins.health--;
            if (DataManager.ins.health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if(collision.gameObject.tag == "Ground")
        {
            GameController.ins.isGrounded = true;
            GameController.ins.doubleJump = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            GameController.ins.addApple = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            GameController.ins.addBanana = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Cherry"))
        {
            GameController.ins.addCherries = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            GameController.ins.addKiwi = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Melon"))
        {
            GameController.ins.addMelon
 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Orange"))
        {
            GameController.ins.addOrange = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            GameController.ins.addPineapple = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            GameController.ins.addStrawberry = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {
            GameController.ins.addDiamond = true;
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("death");
    }

    public void RestartLevel()
    {
        DataManager.ins.DataGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public void JumpButton()
    {
        if (GameController.ins.isGrounded)
        {        
            GameController.ins.isGrounded = false;
            rb.velocity = Vector2.up * jumpForce;           
           Invoke("EnableDoubleJump", delayBeforeDoubleJump);
        }
        if (GameController.ins.doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            GameController.ins.doubleJump = false;
        }
    }

    public void LeftButton()
    {
        dirX = -moveSpeed;
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    public void RightButton()
    {
        dirX = moveSpeed;
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void EnableDoubleJump()
    {
        GameController.ins.doubleJump = true;
    }
}
