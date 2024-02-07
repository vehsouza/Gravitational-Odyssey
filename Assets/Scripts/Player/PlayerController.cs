using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D cl;

    [SerializeField] private float gravityValue;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject playerVisual;

    [Header("Sounds")]
    [SerializeField] private SfxHelper sfxHelper;

    public bool hasKey;

    [SerializeField] private float timeUntilRespawn = .2f;

    public LevelLoader levelLoader;

    public bool dead { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        dead = false;
        hasKey = false;
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
        if (collision.gameObject.CompareTag("Spike"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        anim.SetTrigger("Dead");
        cl.enabled = false;
        dead = true;
        Invoke("Respawn", timeUntilRespawn);
    }


    private void Respawn()
    {
        dead = false;
        levelLoader.ResetLevel();
    }
}
