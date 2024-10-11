using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMngr : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    private void OnEnable()
    {
        if (playerMovement == null)
        {
            playerMovement = new PlayerMovement();

            playerMovement.Ground.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
