using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeshiftController : MonoBehaviour
{
    //Connected Objects
    [SerializeField] GameObject form_Human;
    [SerializeField] GameObject form_Heavy;
    [SerializeField] GameObject form_Small;
    [SerializeField] GameObject form_Flyer;
    GameObject oldForm;

    //[SerializeField] GameObject fXController;
    [SerializeField] ParticleController p_Controller;
    protected CharacterController _controller;
    




    // Start is called before the first frame update
    void Start()
    {
        if (oldForm == null)
        {
            oldForm = form_Human;
        }
        oldForm.gameObject.SetActive(true);

        print("Current Form: " + oldForm);

        _controller = oldForm.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = oldForm.transform.position;
        //transform.rotation = oldForm.transform.rotation;

        ControlShifting();

        //In case the player's current form is accidentally cleared, they will default to human
        if (oldForm == null)
        {
            ShapeShift(form_Human);
        }
    }

    public void ControlShifting()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ShapeShift(form_Human);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ShapeShift(form_Heavy);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ShapeShift(form_Small);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ShapeShift(form_Flyer);
            }
        }
    }

    // ABSTRACTION - The ShapeShift method returns a gameobject that becomes the player's new form when ShapeShift is called
    // One only needs to call the method and specify an object, and they can transform the player into whatever they want
    public GameObject ShapeShift(GameObject newForm)
    {
        if (newForm != oldForm)
        {
            print("Shifting from " + oldForm + " to " + newForm);

            oldForm.gameObject.SetActive(false);

            newForm.transform.position = oldForm.transform.position;
            newForm.transform.rotation = oldForm.transform.rotation;

            newForm.gameObject.SetActive(true);
            
            //The visual effects of transformation only occur if they are not currently playing to avoid spam
            if (p_Controller.shiftSmoke.isPlaying == false)
            {
                p_Controller.transform.position = newForm.transform.position;
                p_Controller.ShiftEffect();
            }

            oldForm = newForm;
            _controller = oldForm.gameObject.GetComponent<CharacterController>();
        }
        else
        {
            print("Form not changed from " + oldForm);
        }

        return oldForm;
    }
}
