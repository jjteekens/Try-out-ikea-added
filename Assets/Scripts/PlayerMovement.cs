using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    float crouchOffset = -0.75f;

    public Sprite Standing;
    public Sprite Crouching;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]public float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;

    private enum MovementState {idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        sprite.sprite = Standing;
        StandingSize = coll.size;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.S))
        {
            sprite.sprite = Crouching;
            coll.size = new Vector2(coll.size.x, 0.9f);
            coll.offset = new Vector2(0, crouchOffset);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            sprite.sprite = Standing;
            coll.size = new Vector2(coll.size.x, 1.8f);
            coll.offset = new Vector2(0, -0.285375f);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

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
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
