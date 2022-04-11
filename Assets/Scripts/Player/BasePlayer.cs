using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    // INHERITANCE - The BasePlayer class functions as a shared interface for all of it's children, which are the forms the player can take

    //Basic player properties


    // ENCAPSULATION - playerSpeed returns a backing field b_playerSpeed
    // Setter validation ensures that playerSpeed cannot be a negative number; this would invert controls
    // playerSpeed defaults to 0f in case of this error

    private float b_playerSpeed = 0f;
    public float playerSpeed
    {
        get { return b_playerSpeed; }
        set { 
            if (value < 0.0f)
            {
                print("playerSpeed cannot be negative because that would invert controls.");
                b_playerSpeed = 0.0f;
            }
            else
            {
                b_playerSpeed = value;
            }            
        }
    }

    protected float rotSpeedL = 3f;
    protected float rotSpeedA;
    protected float currentRot;
    protected float jumpHeight = 0f;
    protected float gravityL = 100.0f;
    protected float gravityA = 1;
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
        float inputLR = Input.GetAxis("Horizontal");
        float inputFB = Input.GetAxis("Vertical");

        if (_controller.isGrounded == true)
        {
            moveDir = new Vector3(inputLR, 0, inputFB);
            moveDir *= b_playerSpeed;
        }

        //Rotates player to face the direction of movement
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, currentRot);
        } else if (moveDir == Vector3.zero)
        {
            //Prevent the player model from aiming downwards when grounded
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }

        if (_controller.isGrounded && moveDir.y <= 0)
        {
            currentRot = rotSpeedL;
            moveDir.y -= gravityL * Time.fixedDeltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDir.y = 0;
                    moveDir.y = jumpHeight;
                }
        }
        else if (!_controller.isGrounded)
        {
            currentRot = rotSpeedA;
            moveDir.y -= gravityA * Time.fixedDeltaTime;

            //Form_Flyer can jump in midair
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.CompareTag("Form_Flyer"))
            {
                moveDir = new Vector3(inputLR, 0, inputFB);
                moveDir *= b_playerSpeed;
                moveDir.y = 0;
                moveDir.y = jumpHeight;
            }
        }

        _controller.Move(moveDir * Time.deltaTime);
    }
}
