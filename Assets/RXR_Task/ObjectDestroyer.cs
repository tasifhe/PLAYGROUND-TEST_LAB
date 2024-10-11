using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public string groundTag = "Ground";

    public void DestroyObject(GameObject objectToDestroy)
    {
        if (objectToDestroy.CompareTag(groundTag))
        {
            Destroy(objectToDestroy);
        }
    }
}
