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

        playerSpeed = 4;
        jumpHeight = 5f;
        gravityA = 0.25f;
        currentRot = rotSpeedL;

        float inputLR = Input.GetAxis("Horizontal");
        float inputFB = Input.GetAxis("Vertical");

        if (_controller.isGrounded && moveDir.y <= 0)
        {
            moveDir = new Vector3(inputLR, 0, inputFB);
            if (moveDir.y <= 0)
            {                
                moveDir.y -= gravityL * Time.fixedDeltaTime;
            }
        }
        else if (!_controller.isGrounded)
        {
            moveDir = new Vector3(inputLR, transform.position.y, inputFB);
            //moveDir.y -= gravityA * Time.fixedDeltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //moveDir.y = 0;
            moveDir.y += jumpHeight;
        }
        moveDir *= playerSpeed;

        //Rotates player to face the direction of movement
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }

        _controller.Move(moveDir * Time.deltaTime);
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
