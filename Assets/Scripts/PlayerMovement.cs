using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float dirX;
    public float delayBeforeDoubleJump;
    private int trapCollisionCount = 0; 

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float fanForce = 26f;

    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;

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
        if(((UIGame)UIController.ins.currentScreen).joyStick.Horizontal >= .2f)
        {
            dirX = moveSpeed;
        }
        else if(((UIGame)UIController.ins.currentScreen).joyStick.Horizontal <= -.2f)
        {
            dirX = -moveSpeed;
        }
        else
        {
            dirX = 0f;
        }
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(.05f, 1.5f), 0, jumpableGround);
        if(isWallTouch && !GameController.ins.isGrounded && dirX != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, fanForce);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            AudioManager.ins.PlaySFX("click");
            trapCollisionCount++;
            DataManager.ins.health--;
            if(trapCollisionCount >= 2)
            {
                AudioManager.ins.PlaySFX("death");
                Die();
            }
            if (DataManager.ins.health == 0)
            {
                AudioManager.ins.PlaySFX("death");
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            trapCollisionCount--;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addApple = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addBanana = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Cherry"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addCherries = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addKiwi = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Melon"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addMelon = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Orange"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addOrange = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addPineapple = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            AudioManager.ins.PlaySFX("fruits");
            GameController.ins.addStrawberry = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {
            AudioManager.ins.PlaySFX("diamond");
            GameController.ins.addDiamond = true;
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("death");
        StartCoroutine(DisableBodyType());
    }

    IEnumerator DisableBodyType()
    {
        yield return new WaitForSeconds(1.5f);
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void RestartLevel()
    {
        DataManager.ins.DataGame();
        ((UIGame)UIController.ins.currentScreen).joyStick.ResetValue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GetHurt()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetLayerWeight(1, 0);
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

    void EnableDoubleJump()
    {
        GameController.ins.doubleJump = true;
    }
}
