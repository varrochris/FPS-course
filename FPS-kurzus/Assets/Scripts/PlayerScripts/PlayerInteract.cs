using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;

    private PlayerUI playerUI;
    private InputManager inputManager;
    private WeaponHolder weaponHolder;


    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        weaponHolder = GetComponent<WeaponHolder>();
    }

    private void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, distance, layerMask))
        {
            if(raycastHit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.interatctMessage);
                if (inputManager.playerInput.Player.Interact.triggered)
                {
                    interactable.BaseInteract();

                    Weapon weaponToAdd = interactable.GetComponent<Weapon>();

                    if (!weaponHolder.AreSlotsFull() && weaponToAdd != null)
                    {
                        weaponHolder.AddWeapon(weaponToAdd);
                    }
                }
            }
        }
    }
}
