using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public ObjectDuplicator objectDuplicator;
    public ObjectDestroyer objectDestroyer;

    private bool objectOnGround = false;
    private GameObject duplicatedObject;

    void Start()
    {
        objectDuplicator = GetComponent<ObjectDuplicator>();
        objectDuplicator.OnObjectDuplicated += HandleObjectDuplicated;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            FindObject();
            objectDuplicator.ResetHasBeenDuplicated();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            objectDuplicator.DuplicateObject();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            objectDuplicator.AddRigidbody();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            objectDuplicator.EnableGravity();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (objectOnGround && duplicatedObject != null)
            {
                objectDestroyer.DestroyObject(duplicatedObject);
                duplicatedObject = null;
                objectOnGround = false;
            }
        }
    }

    private void FindObject()
    {
        GameObject foundObject = objectDuplicator.FindObjectWithTag("FindableObject");
        if (foundObject != null)
        {
            duplicatedObject = null;
            objectDuplicator.SetObjectToDuplicate(foundObject);
        }
    }

    private void HandleObjectDuplicated(GameObject duplicatedObject)
    {
        this.duplicatedObject = duplicatedObject;
    }

    public void SetObjectOnGround(bool isOnGround)
    {
        objectOnGround = isOnGround;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectDuplicator.GetDuplicatedObject())
        {
            objectOnGround = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectDuplicator.GetDuplicatedObject())
        {
            objectOnGround = false;
        }
    }
}
