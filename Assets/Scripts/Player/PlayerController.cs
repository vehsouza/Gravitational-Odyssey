using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject playerVisual;

    [Header("Movement")]
    [SerializeField] private float speed;
    private float moveInput;
    private bool isRunning;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;
    public bool isJumping;

    [Header("Sounds")]
    [SerializeField] private SfxHelper sfxHelper;

    [Header("GroundCheck")]
    [SerializeField] private Transform checkGround;
    [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float gravityValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //isRunning = false;
    }

    private void FixedUpdate()
    {
        /*if (!SwitchGravity.switchingGravity)
        {
            ApplyMovement();
        }*/
    }

    private void Update()
    {
        Animation();
        Flip();
        /*if(!SwitchGravity.switchingGravity)
        {
            GetInput();
        }*/
        //GetMovement();
    }

   /* private void GetInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }

        if(Input.GetButton("Jump") && isJumping)
        {
            JumpLonger();
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }*/

    /*private void ApplyMovement()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }*/

    private void Flip()
    {
        if(moveInput > 0)
        {
            playerVisual.transform.localScale = new Vector3(1, 1, 1);
        }
        if (moveInput < 0)
        {
            playerVisual.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /*private void GetMovement()
    {
        if(rb.velocity.x > 0f)
        {
            isRunning = true;
        }
        if(rb.velocity.x < -0.1f)
        {
            isRunning = true;
        }
        else if(rb.velocity.x == 0f)
        {
            isRunning = false;
        }
    }*/

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(checkGround.position, checkGroundRadius, groundLayer);
    }

    /*private void Jump()
    {
        isJumping = true;
        jumpTimeCounter = jumpTime;
        rb.velocity = new Vector2(rb.velocity.x * 0.5f, jumpForce);

        sfxHelper.PlayJumpSfx();
    }

    private void JumpLonger()
    {
        if (jumpTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }*/

    public void RotatePlayer(float angle)
    {
        transform.Rotate(0f, 0f, angle);
    }

    public void TakeDownGravity()
    {
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0f, 0.1f);
    }

    public void GiveBackGravity()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        rb.gravityScale = gravityValue; 
    }

    private void Animation()
    {
        //anim.SetBool("isRunning", isRunning);
        //anim.SetBool("isJumping", isJumping);
        anim.SetBool("isGraviting", SwitchGravity.switchingGravity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            sfxHelper.PlayLandingSfx();
        }
    }
}
