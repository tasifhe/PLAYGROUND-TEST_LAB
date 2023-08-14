using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private ObjectFinder objectFinder;

    public ObjectDuplicator objectDuplicator;

    //private GameObject duplicatedObject;

    void Start()
    {
        objectFinder = GetComponent<ObjectFinder>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            //ProcessNextObject();
            RayCastForObject();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            objectDuplicator.DuplicateObject();
            //duplicatedObject = objectDuplicator.GetDuplicatedObject();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            objectDuplicator.AddRigidbodyToDuplicatedObject();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            objectDuplicator.EnableGravity();
        }
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            
        }*/
    }

    /*private void ProcessNextObject()
    {
        GameObject nextObject = objectFinder.GetNextObject();

        if(nextObject != null)
        {
            objectDuplicator.objectToDuplicate = nextObject;
            Debug.Log($"Assigned object '{nextObject.name}' to objectToDuplicate");
        }
        else
        {
            Debug.Log($"No objects found with name containing '{objectFinder.objectNameContains}'");
        }
    }*/
    private void RayCastForObject()
    {
        // Create a ray that points straight forward from the camera, in the Z direction
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        // Raycast and check if it hits something (range of 100 units for example)
        if (Physics.Raycast(ray, out hit, 10))
        {
            objectDuplicator.objectToDuplicate = hit.transform.gameObject;
            Debug.Log($"Selected object {objectDuplicator.objectToDuplicate.name} for duplication");
        }

        // Draw a line to visualize the raycast
        Debug.DrawLine(ray.origin, hit.point, Color.blue);
    }

}
