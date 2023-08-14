using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RXR.FP;

public class testScript : MonoBehaviour
{
    public Transform t1;
    public Transform t2;

    public PlayerMovementController player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            player.TeleportToLocation(t1.position);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.TeleportToLocation(t2.position);
        }
    }
}
