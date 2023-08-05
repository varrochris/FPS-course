using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponHolder, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
           
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }


    protected override void Interact()
    {
        Debug.Log("Pick up" + gameObject.name);
        PickUp();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(weaponHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }
}
