//using UnityEngine;

//public class ObjectManipulatorV2 : MonoBehaviour
//{
//    public Camera mainCamera; // Reference to the main camera (assign in Inspector)
//    public GameObject objectToDuplicate; // Prefab of the object to be duplicated (assign in Inspector)

//    private GameObject selectedObject; // Stores the currently selected object

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.O))
//        {
//            RaycastHit hit;
//            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit))
//            {
//                selectedObject = hit.collider.gameObject;
//                Debug.Log("Selected object: " + selectedObject.name); // Optional debugging message
//            }
//            else
//            {
//                selectedObject = null; // Clear selection if nothing is hit
//                Debug.Log("No object selected"); // Optional debugging message
//            }
//        }

//        if (Input.GetKeyDown(KeyCode.I) && selectedObject != null)
//        {
//            // Instantiate the selected object at the raycast end point
//            Vector3 instantiatePosition = hit.point; // Use the hit point from the previous raycast
//            Quaternion instantiateRotation = selectedObject.transform.rotation;
//            GameObject instantiatedObject = Instantiate(objectToDuplicate, instantiatePosition, instantiateRotation);

//            // Add rigidbody (gravity disabled) to the instantiated object
//            Rigidbody instantiatedRigidbody = instantiatedObject.AddComponent<Rigidbody>();
//            instantiatedRigidbody.isKinematic = true; // Disable gravity

//            // Optional: Add functionality for "u", "y", and "t" keys
//            if (Input.GetKeyDown(KeyCode.U))
//            {
//                if (instantiatedRigidbody != null)
//                {
//                    instantiatedRigidbody.isKinematic = true; // Disable gravity again
//                    Debug.Log("Rigidbody added (gravity disabled)");
//                }
//            }

//            if (Input.GetKeyDown(KeyCode.Y) && instantiatedRigidbody != null)
//            {
//                instantiatedRigidbody.isKinematic = false; // Enable gravity
//                Debug.Log("Rigidbody enabled");
//            }

//            if (Input.GetKeyDown(KeyCode.T) && instantiatedObject != null)
//            {
//                Destroy(instantiatedObject);
//                selectedObject = null; // Clear selection
//                Debug.Log("Object destroyed");
//            }
//        }
//    }
//}
