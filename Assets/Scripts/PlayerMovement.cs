using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float dirX = 0f;

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
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(dirX * moveSpeed, rb.velocity.y, 0);
         if(Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, fanForce);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            GameController.ins.addScore = true;
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
        DataManager.ins.StartDataGame();        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
