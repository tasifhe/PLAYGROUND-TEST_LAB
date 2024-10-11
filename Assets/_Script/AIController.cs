using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray movePosition = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out RaycastHit hitInfo))
            {
                MoveAgent(hitInfo.point);
            }
        }
    }

    private void MoveAgent(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
