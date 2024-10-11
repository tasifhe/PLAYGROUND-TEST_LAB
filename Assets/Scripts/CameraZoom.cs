using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float targetSize = 5f;
    public float zoomSpeed = 1f;
    private Camera cam;
    private float defualtSize;
    private bool isZooming = false;
    private bool isZoomedIn = false;

    private void Start()
    {
        cam = GetComponent<Camera>();
        if(cam == null)
        {
            Debug.LogError("Camera component not found on this object");
            enabled = false;
            return;
        }
        defualtSize = cam.orthographicSize;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && !isZooming)
        {
            if (isZoomedIn)
            {
                StartCoroutine(ZoomToTargetSize(defualtSize));
            }
            else
            {
                StartCoroutine(ZoomToTargetSize(targetSize));
            }
        }
    }
    IEnumerator ZoomToTargetSize(float newSize)
    {
        isZooming = true;
        while (Mathf.Abs(cam.orthographicSize - newSize) > 0.05f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * zoomSpeed);
            yield return null;
        }
        cam.orthographicSize = newSize;
        isZooming = false;
        isZoomedIn = (newSize == targetSize);
    }
}
