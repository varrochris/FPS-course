using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerController playerController;
    private PlayerLook playerLook;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerController = GetComponent<PlayerController>();
        playerLook = GetComponent<PlayerLook>();
        playerInput.Player.Jump.performed += ctx => playerController.PlayerJump();

    }

    private void FixedUpdate()
    {
        playerController.PlayerMovement(playerInput.Player.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.PlayerWatch(playerInput.Player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}