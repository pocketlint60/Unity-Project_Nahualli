using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Small : BasePlayer
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
        speedMult = 8f;
    }

    public override void PlayProperties()
    {
        base.PlayProperties();
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
