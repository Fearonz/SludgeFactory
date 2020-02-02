using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    FMOD.Studio.EventInstance playJump;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        playJump = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/player/Jump");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        if (!LevelController.instance.isPlant)
            move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded && !LevelController.instance.isPlant)
        {
            velocity.y = jumpTakeOffSpeed;
            playJump.start();
            // animator.SetBool("IsJump", true);
            //animator.SetTrigger("jump");
            animator.Play("jumping");

        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;

            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (-move.x > 0.01f) : (-move.x < 0.01f));
        if (!flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // animator.SetBool("jumping", grounded);
        animator.SetBool("grounded", grounded);
        //Debug.Log(Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public void Death()
    {
        animator.Play("Death");
    }
}