using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera camera;

    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;

    private PlayerUI playerUI;
    private PlayerInput playerInput;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, distance, layerMask))
        {
            if(raycastHit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.interatctMessage);
                if (playerInput.Player.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
