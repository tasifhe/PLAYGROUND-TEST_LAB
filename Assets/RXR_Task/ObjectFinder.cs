using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    public string objectNameContains = "Object_1";

    private Queue<GameObject> objectsQueue = new Queue<GameObject>();

    void Start()
    {
        FindObjectsWithNameContains();
    }

    public void FindObjectsWithNameContains()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach(GameObject gameObject in gameObjects)
        {
            if (gameObject.name.Contains(objectNameContains))
            {
                objectsQueue.Enqueue(gameObject);
            }
        }
    }

    public GameObject GetNextObject()
    {
        if(objectsQueue.TryDequeue(out GameObject gameObject))
        {
            return gameObject;
        }
        else
        {
            return null;
        }
    }
}
