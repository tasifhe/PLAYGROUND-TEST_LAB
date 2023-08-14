using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public Transform duplicatePosition;

    private GameObject duplicatedObject;

    public void DuplicateObject()
    {
        if (objectToDuplicate != null && duplicatePosition != null)
        {
            duplicatedObject = Instantiate(objectToDuplicate, duplicatePosition.position, duplicatePosition.rotation);
            Debug.Log($"Duplicated object: {duplicatedObject.name}");
        }
        else
        {
            Debug.LogError("No object to duplicate or duplicate position specified.");
        }
    }

    public void AddRigidbodyToDuplicatedObject()
    {
        if (duplicatedObject != null)
        {
            Rigidbody rigidBody = duplicatedObject.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                rigidBody = duplicatedObject.AddComponent<Rigidbody>();
            }
            rigidBody.useGravity = false;
            Debug.Log("Added Rigidbody with gravity disabled to duplicated object, press 'Y' to enable gravity.");
        }
        else
        {
            Debug.LogError("No object has been duplicated yet.");
        }
    }

    public void EnableGravity()
    {
        if (duplicatedObject != null)
        {
            Rigidbody rigidbody = duplicatedObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.useGravity = true;
                Debug.Log("Enabled gravity on the duplicated object.");
            }
        }
        else
        {
            Debug.LogError("No Rigidbody attached to the duplicated object.");
        }
    }
}
