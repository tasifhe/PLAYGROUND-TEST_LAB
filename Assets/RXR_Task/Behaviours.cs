using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Behaviours : MonoBehaviour
{
    [SerializeField] private string objectToFind = "red";
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed = 50f;
    [SerializeField] private float zoomDistance = 2f;
    private bool isZoomingIn = false;
    private bool isZoomingOut = false;
    private bool instantiateAfterZoomOut = false;
    private Vector3 targetPosition;
    private Vector3 initialCameraPosition;
    private Vector3 zoomedInPosition;
    private GameObject selectedObject;
    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private void Start()
    {
        initialCameraPosition = cam.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            selectedObject = GameObject.FindWithTag(objectToFind);
            if (selectedObject != null)
            {
                UnityEditor.Selection.activeGameObject = selectedObject;
                isZoomingIn = true;
                isZoomingOut = false;
                zoomedInPosition = selectedObject.transform.position - cam.transform.forward * zoomDistance;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isZoomingOut = true;
            isZoomingIn = false;
            instantiateAfterZoomOut = true;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = selectedObject.gameObject.AddComponent<Rigidbody>();
            }
            rb.isKinematic = true;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (instantiatedObjects.Count > 0)
            {
                Destroy(instantiatedObjects[0]);
                instantiatedObjects.RemoveAt(0);
            }
        }
    }

    private void FixedUpdate()
    {
        CameraZoomInOut();
    }
    private void CameraZoomInOut()
    {
        if (isZoomingIn)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, zoomedInPosition, Time.deltaTime * zoomSpeed);
            if (Vector3.Distance(cam.transform.position, zoomedInPosition) < 0.1f)
            {
                isZoomingIn = false;
            }
        }

        if (isZoomingOut)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, initialCameraPosition, Time.deltaTime * zoomSpeed);
            if (Vector3.Distance(cam.transform.position, initialCameraPosition) < 0.1f)
            {
                isZoomingOut = false;
                if (instantiateAfterZoomOut)
                {
                    if (selectedObject != null)
                    {
                        GameObject newObject = Instantiate(selectedObject, cam.transform.position + cam.transform.forward * zoomDistance, Quaternion.identity);
                        instantiatedObjects.Add(newObject);
                    }
                    instantiateAfterZoomOut = false;
                }
            }
        }
    }
}
