using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Heavy : BasePlayer
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
        playerSpeed = 1.5f;
        jumpHeight = 2f;
        rotSpeedL = .5f;
        rotSpeedA = 0f;
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
