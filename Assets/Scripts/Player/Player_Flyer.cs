using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flyer : BasePlayer
{
    // Start is called before the first frame update
    void Start()
    {
        AssignComponents();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMotion();
    }

    public override void ControlMotion()
    {
        base.ControlMotion();

        jumpHeight = 5f;
        currentRot = rotSpeedL;



        //Hold space to glide, slowing your movement and falling
        if (Input.GetKey(KeyCode.Space) && _controller.velocity.y < 0)
        {            
            playerSpeed = 2;
            rotSpeedL = 0.5f;
            gravityA = 0.1f;
        } else if (_controller.velocity.y >= 0 || !Input.GetKey(KeyCode.Space))
        {
            playerSpeed = 4;
            rotSpeedL = 3f;
            gravityA = .85f;
        }

        //Unlike the other forms, Flyer can move freely in the air
        if (_controller.velocity.y != 0)
        {
            float inputLR = Input.GetAxis("Horizontal");
            float inputFB = Input.GetAxis("Vertical");

            moveDir.x = inputLR * playerSpeed;
            moveDir.z = inputFB * playerSpeed;
        }

    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
