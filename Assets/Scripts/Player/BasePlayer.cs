using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    //Basic player properties
    protected float speedMult = 0f;
    protected float rotSpeed = 2f;
    protected float jumpHeight = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlMotion();
    }

    public virtual void ControlMotion()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, forwardInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate((movementDirection * (speedMult) * inputMagnitude * Time.deltaTime), Space.World);

        //Rotates player to face the direction of movement
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed);
        }
    }

    public virtual void PlayProperties()
    {
        // INHERITANCE - The BasePlayer class contains default information for the player's properties, which subclasses can override to make each Shapeshifting form control differently or have unique functions
        // POLYMORPHISM - PlayProperties contains the basic properties of the player character which change depending on form
        //BasePlayer contains the default state held by the parent Player object; this object cannot move

        PrimeFunction();
    }


    //PrimeFunction is a special interaction that changes depending on the ShapeShifter's form
    public virtual void PrimeFunction()
    {

    }
}
