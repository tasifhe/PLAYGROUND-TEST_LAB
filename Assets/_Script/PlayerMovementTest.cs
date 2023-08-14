using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerSprint();
    }
    public void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, VerticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    public void playerSprint()
    {
        //pressing shift will make player sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
}
