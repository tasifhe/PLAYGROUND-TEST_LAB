using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFind : MonoBehaviour
{
    public string objectTag = "FindableObject";

    private Queue<GameObject> objectsQueue = new Queue<GameObject>();
    private void Start()
    {
        FindObjectWithTag();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            ProcessNextObject();
        }
    }
    private void FindObjectWithTag()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(objectTag);

        foreach(GameObject gameObject in gameObjects)
        {
            objectsQueue.Enqueue(gameObject);
        }
    }
    private void ProcessNextObject()
    {
        if(objectsQueue.TryDequeue(out GameObject gameObject))
        {
            Debug.Log($"Object Find: { gameObject.name}");
        }
        else
        {
            Debug.Log($"No objetcs found with tag {objectTag}");
        }
    }
}
