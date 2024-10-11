using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerManager : MonoBehaviour
{
    InputMngr inputManager;
    _PlayerController playerController;
    private void Awake()
    {
        inputManager = GetComponent<InputMngr>();
        playerController = GetComponent<_PlayerController>();
    }
    private void LateUpdate()
    {
        inputManager.HandleAllInputs();
        playerController.HandleAllMovement();
    }
    private void FixedUpdate()
    {
        // playerController.HandleAllMovement();
    }
}
