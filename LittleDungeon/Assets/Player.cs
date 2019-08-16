using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public Animator animator;

    Vector2 movement;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Return if it's not players turn
        if (!GameManager.instance.playersTurn) return;

        movement.x = (int)Input.GetAxisRaw("Horizontal");
        movement.y = (int)Input.GetAxisRaw("Vertical");

        // If Input isn't 0, attempt to move
        if (movement.sqrMagnitude > float.Epsilon)
        {
            AttemptMove((int)movement.x, (int)movement.y);
        }

        PlayMovingAnimation();
    }

    protected override void AttemptMove(int xDir, int yDir)
    {
        base.AttemptMove(xDir, yDir);

        PlayIdleAnimation();

        GameManager.instance.playersTurn = false;
    }

    private void PlayMovingAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void PlayIdleAnimation()
    {
        animator.SetFloat("IdleX", movement.x);
        animator.SetFloat("IdleY", movement.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Will check here when picking up items and collided with other object
    }
}
