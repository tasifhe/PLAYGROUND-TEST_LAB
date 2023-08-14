using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform targetportal;
    public Transform currentPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCam.position - currentPortal.position;
        transform.position = targetportal.position + playerOffsetFromPortal;

        float angularDiff = Quaternion.Angle(currentPortal.rotation, currentPortal.rotation);

        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDirection = portalRotationDiff * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
