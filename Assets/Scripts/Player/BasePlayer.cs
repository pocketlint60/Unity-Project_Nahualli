using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    CharacterController playerControls;

    //Basic player properties
    protected float speedMult;
    protected float jumpHeight;


    // Start is called before the first frame update
    void Start()
    {
        playerControls = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMotion();
    }

    public void ControlMotion()
    {
        
    }

    public virtual void PlayProperties()
    {
        // INHERITANCE - The BasePlayer class contains default information for the player's properties, which subclasses can override to make each Shapeshifting form control differently or have unique functions
        // POLYMORPHISM - PlayProperties contains the basic properties of the player character which change depending on form
        //BasePlayer contains the default state held by the parent Player object; this object cannot move

        speedMult = 0f;
        jumpHeight = 0f;
        PrimeFunction();
    }


    //PrimeFunction is a special interaction that changes depending on the ShapeShifter's form
    public virtual void PrimeFunction()
    {

    }
}
