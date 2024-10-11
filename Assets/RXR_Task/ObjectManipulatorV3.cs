using System;
using System.Collections;
using UnityEngine;

public class ObjectManipulatorV3 : MonoBehaviour
{
    public GameObject targetObject;
    public Transform playerTransform;
    public float rayDistance = 10f;
    private GameObject selectedObject;

    [SerializeField] LayerMask layerMask;
    RaycastHit hitinfo;

    private void Update()
    {
        Debug.DrawRay(playerTransform.position, playerTransform.forward * rayDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.O))
        {
            FindTargetObject();
        }
        else if (Input.GetKeyDown(KeyCode.I) && targetObject != null)
        {
            DuplicateObject(targetObject);
        }
        else if (Input.GetKeyDown(KeyCode.U) && targetObject != null)
        {
            AddRigidbody(targetObject, false);
        }
        else if (Input.GetKeyDown(KeyCode.Y) && targetObject != null)
        {
            EnableRigidbody(targetObject);
        }
        else if (Input.GetKeyDown(KeyCode.T) && targetObject != null)
        {
            DestroyOnGround(targetObject);
        }
        //FindTargetObject();
    }

    void FindTargetObject()
    {
        Ray ray = new Ray(playerTransform.position, playerTransform.forward);

        if (Physics.Raycast(ray, out hitinfo, rayDistance, layerMask, QueryTriggerInteraction.Ignore))
        {
            targetObject = hitinfo.collider.gameObject;
            Debug.Log("Hit object: " + hitinfo.collider.gameObject.name);
            Debug.DrawRay(playerTransform.position, playerTransform.forward * rayDistance, Color.red);
        }
        else
        {
            targetObject = null;
            Debug.Log("No object hit");
            Debug.DrawRay(playerTransform.position, playerTransform.forward * rayDistance, Color.green);
        }
    }
    void DuplicateObject(GameObject original)
    {
        Instantiate(original, original.transform.position + Vector3.right, original.transform.rotation);
    }

    void AddRigidbody(GameObject obj, bool useGravity)
    {
        var rb = obj.AddComponent<Rigidbody>();
        if (rb == null)
        {
            rb = obj.GetComponent<Rigidbody>();
        }

        rb.useGravity = useGravity;
    }

    void EnableRigidbody(GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }

    void DestroyOnGround(GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            RaycastHit hit;
            if (Physics.Raycast(obj.transform.position, Vector3.down, out hit, 1f))
            {
                Destroy(obj);
            }
        }
    }
}
