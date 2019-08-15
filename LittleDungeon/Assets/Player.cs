using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Return if it's not players turn
        if (!GameManager.instance.playersTurn) return;

        int horizontal = (int) Input.GetAxisRaw("Horizontal");
        int vertical = (int) Input.GetAxisRaw("Vertical");

        // For now no diagonal movement, so when x isn't 0 y is turned to 0
        if (horizontal != 0)
        {
            vertical = 0;
        }

        // If Input isn't 0, attempt to move
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove(horizontal, vertical);
        }
    }

    protected override void AttemptMove(int xDir, int yDir)
    {
        base.AttemptMove(xDir, yDir);

        GameManager.instance.playersTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Will check here when picking up items and collided with other object
    }
}
