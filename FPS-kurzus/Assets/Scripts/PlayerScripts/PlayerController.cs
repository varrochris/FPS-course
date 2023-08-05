using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    [SerializeField] private float basicSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight;

    [SerializeField] private bool lerpCrouch;
    [SerializeField] private float crouchTimer;
    [SerializeField] private bool  crouching;
    [SerializeField] private bool walking;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        speed = basicSpeed;
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                speed = crouchSpeed;
                characterController.height = Mathf.Lerp(characterController.height,1, p);
            }
            else
            {
                speed = basicSpeed;
                characterController.height = Mathf.Lerp(characterController.height, 2, p);
                if(characterController.height >= 1.8f)
                {
                    lerpCrouch = false;
                }
            }
        }
    }

    public void PlayerMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void PlayerJump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            Debug.Log("Player Jump");
        }
    }

    public void PlayerCrouch()
    {
        lerpCrouch = true;
        crouching = !crouching;
        crouchTimer = 0;
        Debug.Log("Player Crouch");
    }

    public void PlayerWalk()
    {
        walking = !walking;
        if (walking)
        {
            speed = walkSpeed;
        }
        else
        {
            speed = basicSpeed;
        }
        Debug.Log("Player Walk");
    }
}
