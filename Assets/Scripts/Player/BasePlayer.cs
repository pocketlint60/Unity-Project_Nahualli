using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    // INHERITANCE - The BasePlayer class contains default information for the player's properties, which subclasses can override to make each Shapeshifting form control differently or have unique functions

    //Basic player properties
    protected float speedMult = 0f;
    protected float rotSpeed = 2f;
    protected bool groundedPlayer = true;
    protected float jumpHeight = 0f;
    protected float gravity = -15.0f;
    protected Vector3 playerVelocity;

    protected CharacterController _controller;


    // Start is called before the first frame update
    void Start()
    {
        groundedPlayer = _controller.isGrounded;
    }

    //AssignComponents() isn't called in BasePlayer but is used in it's subclasses
    public void AssignComponents()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        //ControlMotion();
        if (_controller.isGrounded == true) groundedPlayer = true;
    }

    public virtual void ControlMotion()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");
        float jumpInput;

        if (groundedPlayer)
        {
            jumpInput = 0;

            //Player positioning calculations
            playerVelocity = new Vector3(horizontalInput, jumpInput, forwardInput);
            float inputMagnitude = Mathf.Clamp01(playerVelocity.magnitude);
            playerVelocity.Normalize();


            //Grounded movement
            if (gameObject.CompareTag("Form_Flyer") != true)
            {
                _controller.SimpleMove((playerVelocity * inputMagnitude) * speedMult);
            }
            else if ((gameObject.CompareTag("Form_Flyer") == true))
            {
                //The Flying Form uses Move() instead of SimpleMove() because Move does not have gravity by default and also does not need to be grounded to move
                _controller.Move(((playerVelocity * inputMagnitude) * speedMult) * Time.deltaTime);
            }

            //Jump movement
            if (Input.GetKey(KeyCode.Space))
            {
                jumpInput = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }

            print(jumpInput);
        }

        //Rotates player to face the direction of movement
        if (playerVelocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(playerVelocity.x, 0, playerVelocity.z), Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed);
        }
    }

    public virtual void ControlJump()
    {        
        //Stops vertical velocity in case of underflow
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (_controller.velocity.y == 0)
        {
            groundedPlayer = true;
            print("Player has landed");
        }


        // Changes the height position of the player.
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            _controller.Move(playerVelocity * Time.deltaTime);            
        } else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }   
    }


    // POLYMORPHISM - PrimeFunction is an overridable function that does nothing in BasePlayer but can be customized by form
    //PrimeFunction is a special interaction that changes depending on the ShapeShifter's form
    public virtual void PrimeFunction()
    {

    }
}
