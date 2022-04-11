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
    }

    public override void ControlMotion()
    {        
        base.ControlMotion();
        playerSpeed = 5.5f;
        jumpHeight = 5f;
        rotSpeedA = rotSpeedL/20;
    }
}
