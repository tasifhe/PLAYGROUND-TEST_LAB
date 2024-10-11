using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    private TDPlayerInput inputActions;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        inputActions = new TDPlayerInput();
        inputActions.Player.Enable();
    }
    private void OnDestroy()
    {
        inputActions.Player.Disable();
    }
    public Vector3 GetMovementInput()
    {
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        return new Vector3(input.x, 0, input.y);
    }

    public bool IsJumping()
    {
        return inputActions.Player.Jump.triggered;
    }
}
