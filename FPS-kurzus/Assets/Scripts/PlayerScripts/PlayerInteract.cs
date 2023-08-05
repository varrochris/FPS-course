using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera camera;

    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, distance, layerMask))
        {
            if(raycastHit.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(raycastHit.collider.GetComponent<Interactable>().interatctMessage);
            }
        }
    }
}
