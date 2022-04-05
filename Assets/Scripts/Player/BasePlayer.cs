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
        
    }

    public virtual void ControlMotion()
    {

    }

    public virtual void ControlJump()
    {        
 
    }


    // POLYMORPHISM - PrimeFunction is an overridable function that does nothing in BasePlayer but can be customized by form
    //PrimeFunction is a special interaction that changes depending on the ShapeShifter's form
    public virtual void PrimeFunction()
    {

    }
}
