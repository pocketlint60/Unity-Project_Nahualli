using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem shiftSmoke;

    // Start is called before the first frame update
    void Start()
    {
        shiftSmoke = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShiftEffect()
    {
        if (shiftSmoke.isPlaying == false)
        {
            shiftSmoke.Play(true);
        } else
        {
            print("Smoke anti-spam");
        }
        
    }
}
