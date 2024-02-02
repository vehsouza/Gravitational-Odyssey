using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float gravityValue;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject playerVisual;

    [Header("Sounds")]
    [SerializeField] private SfxHelper sfxHelper;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Animation();
    }


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
        anim.SetBool("isGraviting", SwitchGravity.switchingGravity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            sfxHelper.PlayLandingSfx();
            anim.SetTrigger("Landing");
        }
    }
}
