using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Human : BasePlayer
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
        //ControlJump();
    }

    public override void ControlMotion()
    {        
        base.ControlMotion();
        playerSpeed = 5.5f;
    }

    public override void ControlJump()
    {
        base.ControlJump();
        jumpHeight = 1f;
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
