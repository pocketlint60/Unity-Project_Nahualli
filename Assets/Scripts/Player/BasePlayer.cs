using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    // INHERITANCE - The BasePlayer class functions as a shared interface for all of it's children, which are the forms the player can take

    //Basic player properties
    protected float rotSpeed = 2f;
    protected float playerSpeed = 0f;
    //protected bool groundedPlayer = true;
    protected float jumpHeight = 0f;
    protected float gravity = 1.0f;
    protected Vector3 moveDir;

    protected CharacterController _controller;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //AssignComponents() isn't called in BasePlayer but is used in it's subclasses
    public void AssignComponents()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ControlMotion()
    {      
        if (_controller.isGrounded == true)
        {
            float inputLR = Input.GetAxis("Horizontal");
            float inputFB = Input.GetAxis("Vertical");

            moveDir = new Vector3(inputLR, 0, inputFB);
            //moveDir = transform.TransformDirection(moveDir);
            moveDir *= playerSpeed;
        }

        //Rotates player to face the direction of movement
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed);

            // The player only rotates on the Y axis when in midair
            if (_controller.isGrounded)
            {

            }
            else if (!_controller.isGrounded)
            {

            }

        }


        if (!_controller.isGrounded)
        {
            moveDir.y -= gravity * Time.fixedDeltaTime;
        }        
        _controller.Move(moveDir * Time.deltaTime);
    }

    public virtual void ControlJump()
    {        
 
    }


    // POLYMORPHISM - PrimeFunction is an overridable function that does nothing in BasePlayer but can be customized by each form
    //PrimeFunction is a special interaction that changes depending on the ShapeShifter's form
    public virtual void PrimeFunction()
    {

    }
}
