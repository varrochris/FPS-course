using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] private float xRotation;
    [SerializeField] private float xSensivity;
    [SerializeField] private float ySensivity;
    [SerializeField] private float clampAngle;

    public void PlayerWatch(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX *Time.deltaTime)* xSensivity);
    }
}
