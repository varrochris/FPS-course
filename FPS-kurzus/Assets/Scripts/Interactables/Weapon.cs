using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable
{
    protected override void Interact()
    {
        Debug.Log("Pick up" + gameObject.name);
    }
}
