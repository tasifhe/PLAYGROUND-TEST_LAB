using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_PlayerController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Vector3 movementInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private CharacterController controller;

    [Header("Gravity Parameters:")]
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkerRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 gravityVector;
    [SerializeField] private float gravityValue;
    [SerializeField] private int jumpHeight;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movementInput = InputHandler.Instance.GetMovementInput();

        ApplyGravity();
        MovePlayer();
        RotatePlayer();
        Respawn();
    }

    private void MovePlayer()
    {
        controller.Move(movementInput * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        if (movementInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        }
    }

    private void ApplyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkerRadius, groundLayer);

        if (isGrounded)
        {
            gravityVector.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            gravityVector.y += gravityValue * Time.deltaTime;
        }

        controller.Move(gravityVector * Time.deltaTime);
    }

    private void Jump()
    {
        gravityVector.y += Mathf.Sqrt(gravityValue * jumpHeight * -2);
    }

    private void Respawn()
    {
        if (transform.position.y <= -10f)
        {
            transform.position = respawnPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireSphere(groundCheck.position, checkerRadius);
    }
}
