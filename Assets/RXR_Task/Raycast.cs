using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    RaycastHit hitinfo;
    public Transform playerTransform;
    public float rayDistance = 100f;

    void Update()
    {
        Ray ray = new Ray(playerTransform.position, playerTransform.forward);

        if (Physics.Raycast(ray, out hitinfo, rayDistance, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Hit object: " + hitinfo.collider.gameObject.name);
            Debug.DrawRay(playerTransform.position, playerTransform.forward * rayDistance, Color.red);
        }
        else
        {
            Debug.Log("No object hit");
            Debug.DrawRay(playerTransform.position, playerTransform.forward * rayDistance, Color.green);
        }
    }
}
