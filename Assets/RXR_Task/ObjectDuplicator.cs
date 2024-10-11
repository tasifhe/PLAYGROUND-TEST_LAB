using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public Transform duplicatePosition;

    private GameObject duplicatedObject;
    private bool hasBeenDuplicated = false;

    public delegate void ObjectDuplicatedHandler(GameObject duplicatedObject);
    public event ObjectDuplicatedHandler OnObjectDuplicated;

    public void SetObjectToDuplicate(GameObject objectToDuplicate)
    {
        this.objectToDuplicate = objectToDuplicate;
    }

    public void DuplicateObject()
    {
        if (!hasBeenDuplicated && objectToDuplicate != null && duplicatePosition != null)
        {
            duplicatedObject = Instantiate(objectToDuplicate, duplicatePosition.position, duplicatePosition.rotation);
            hasBeenDuplicated = true;

            OnObjectDuplicated?.Invoke(duplicatedObject);
        }
        else
        {
            Debug.LogError("Cannot duplicate object. Check conditions.");
        }
    }

    public void AddRigidbody()
    {
        if (duplicatedObject != null)
        {
            Rigidbody rigidBody = duplicatedObject.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                rigidBody = duplicatedObject.AddComponent<Rigidbody>();
            }
            rigidBody.useGravity = false;
        }
        else
        {
            Debug.LogError("No object duplicated yet.");
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
            }
            else
            {
                Debug.LogError("No Rigidbody attached to object.");
            }
        }
    }

    public GameObject GetDuplicatedObject()
    {
        return duplicatedObject;
    }

    public void ResetHasBeenDuplicated()
    {
        hasBeenDuplicated = false;
    }

    public GameObject FindObjectWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        if (objectsWithTag.Length > 0)
        {
            return objectsWithTag[0];
        }
        return null;
    }
}
