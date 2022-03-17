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

    // Start is called before the first frame update
    void Start()
    {
        GameObject form_Human = this.form_Human;
        GameObject form_Heavy = this.form_Heavy;
        GameObject form_Small = this.form_Small;
        GameObject form_Flyer = this.form_Flyer;

        //PlayProperties();
        oldForm = form_Human;
        oldForm.gameObject.SetActive(true);

        print("Current Form: " + oldForm);
    }

    // Update is called once per frame
    void Update()
    {
        ControlShifting();
        //In case the player's current form is accidentally cleared, they will default to human
        if (oldForm == null)
        {
            ShapeShift(form_Human);
        }
    }

    public void ControlShifting()
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
        };
    }

    // ENCAPSULATION - The ShapeShift method returns a gameobject that becomes the player's new form when ShapeShift is called
    //One only needs to call the method and specify an object, and they can transform the player into whatever they want
    public GameObject ShapeShift(GameObject newForm)
    {
        if (newForm != oldForm)
        {
            print("Shifting from " + oldForm + " to " + newForm);

            oldForm.gameObject.SetActive(false);

            newForm.transform.position = oldForm.transform.position;
            newForm.transform.rotation = oldForm.transform.rotation;

            newForm.gameObject.SetActive(true);

            oldForm = newForm;
        }
        else
        {
            print("Form not changed from " + oldForm);
        }

        return oldForm;
    }
}
