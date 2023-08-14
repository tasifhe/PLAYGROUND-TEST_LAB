using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerController : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody playerRigidbody;
    Vector3 moveDirection;
    Transform cameraObject;
    [SerializeField]
    private float movementSpeed = 7f;
    [SerializeField]
    private float rotationSpeed = 7f;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= movementSpeed;

        // Force the movement through the Rigidbody for smoother results
        playerRigidbody.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime);
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // Using MoveRotation instead of transform.rotation
        playerRigidbody.MoveRotation(Quaternion.Slerp(playerRigidbody.rotation, targetRotation, rotationSpeed * Time.deltaTime));
    }
}
