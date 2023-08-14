using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RXR.FP;

public class _PortalTeleporter : MonoBehaviour
{
    public Transform playerTransform;
    public Transform reciever;
    public PlayerMovementController playerCC;

    private bool playerIsOverlapping = false;
    private const float RotationOffset = 180f;

    private bool canTeleport = true;
    public float cooldownTime = 1.0f;
    private float nextTeleportTime = 0;

    void Update()
    {
        if(playerIsOverlapping && canTeleport)
        {
            TeleportPlayerIfOverlapping();
        }
    }
    void TeleportPlayerIfOverlapping()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = playerTransform.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //Debug.Log(dotProduct);

            if (dotProduct < 0)  //if true the player moves across the portal
            {
                //Teleport the player to the receiver portal
                float rotaionDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotaionDiff += RotationOffset;
                playerTransform.Rotate(Vector3.up, rotaionDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotaionDiff, 0f) * portalToPlayer;
                //playerTransform.position = reciever.position + positionOffset;
                playerCC.TeleportToLocation(reciever.position + positionOffset);

                //playerIsOverlapping = false;
                nextTeleportTime = Time.time + cooldownTime;
                canTeleport = false;
                StartCoroutine(ResetCooldown());
            }
        }
    }
    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canTeleport = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
