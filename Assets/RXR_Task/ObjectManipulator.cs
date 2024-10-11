using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    public float raycastDistance = 100f;
    [SerializeField]
    private GameObject selectedObject;

    public float duplicateDistance = 2f;

    void Update()
    {
        CastRay();
        HandleInput();
    }

    void CastRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            //Debug.Log("Hit object: " + hit.transform.name);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            selectedObject = hit.transform.gameObject;
        }
        else
        {
            //Debug.Log("No object hit");
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.O) && selectedObject != null)
        {
            if(selectedObject.activeSelf)
            {
                selectedObject.SetActive(false);
                Debug.Log("Disabled object: " + selectedObject.name);
            }
            else
            {
                selectedObject.SetActive(true);
                Debug.Log("Enabled object: " + selectedObject.name);
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && selectedObject != null)
        {
            DuplicateObject(selectedObject);
        }

        if (Input.GetKeyDown(KeyCode.U) && selectedObject != null)
        {
            AddRigidbodyToSelectedObject();
        }

        if (Input.GetKeyDown(KeyCode.Y) && selectedObject != null)
        {
            EnableRigidbodyOnSelectedObject();
        }

        if (Input.GetKeyDown(KeyCode.T) && selectedObject != null)
        {
            DestroySelectedObject();
        }
    }

    void DuplicateObject(GameObject originalObject)
    {
        Vector3 duplicatePosition = transform.position + (transform.forward * duplicateDistance);

        GameObject duplicate = Instantiate(originalObject, duplicatePosition, originalObject.transform.rotation);

        Debug.Log("Duplicated object: " + duplicate.name);
    }
    void AddRigidbodyToSelectedObject()
    {
        if(selectedObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = selectedObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            Debug.Log("Rigidbody added to object: " + selectedObject.name);
        }
        else
        {
            Debug.Log("Object already has a Rigidbody");
        }
    }
    void EnableRigidbodyOnSelectedObject()
    {
        Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.isKinematic = false;
            Debug.Log("Rigidbody enabled for object: " + selectedObject.name);
        }
        else
        {
            Debug.Log("Object does not have a Rigidbody");
        }
    }
    void DestroySelectedObject()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
            Debug.Log("Destroyed object: " + selectedObject.name);
            selectedObject = null; // Clear the reference to avoid NullReferenceException
        }
        else
        {
            Debug.Log("No object selected to destroy.");
        }
    }
}