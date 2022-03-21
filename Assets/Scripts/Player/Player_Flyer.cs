using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flyer : BasePlayer
{
    // Start is called before the first frame update
    void Start()
    {

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

    public override void PlayProperties()
    {
        base.PlayProperties();
    }

    public override void PrimeFunction()
    {
        base.PrimeFunction();
    }
}
