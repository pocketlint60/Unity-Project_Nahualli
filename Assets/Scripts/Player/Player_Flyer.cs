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
        speedMult = 5f;
    }

    public override void ControlJump()
    {
        base.ControlJump();
        gravity = -0.5f;
        jumpHeight = 5f;
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
