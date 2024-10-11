using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class ObjectControllerV2 : MonoBehaviour
{
    public float rayDistance = 100f;
    public LayerMask hitLayers;
    public string prefabSavePath = "Assets/Prefabs/";
    public Transform instantiatePosition;

    private GameObject selectedObject;

    private void Update()
    {
        CastRay();
        if(Input.GetKeyDown(KeyCode.O) && selectedObject != null)
        {
            SaveSelectedObjectAsPrefab();
        }
        if(Input.GetKeyDown(KeyCode.I) && selectedObject != null)
        {
            InstantiateSelectedObject();
        }
    }
    void CastRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance, hitLayers))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
            selectedObject = hit.collider.gameObject;
        }
        else
        {
            Debug.Log("No object hit");
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
            selectedObject = null;
        }
    }
    void SaveSelectedObjectAsPrefab()
    {
        string prefabName = selectedObject.name + ".prefab";
        string prefabPath = prefabSavePath + prefabName;

        #if UNITY_EDITOR
        UnityEditor.PrefabUtility.SaveAsPrefabAsset(selectedObject, prefabPath);
        Debug.Log("Prefab saved at: " + prefabPath);
        #else
        Debug.Log("Prefab saving only works in the Unity Editor");
        #endif
    }
    void InstantiateSelectedObject()
    {
        string prefabName = selectedObject.name + ".prefab";
        string prefabPath = prefabSavePath + prefabName;

        #if UNITY_EDITOR
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if(prefab != null)
        {
            Instantiate(prefab, instantiatePosition.position, instantiatePosition.rotation);
            Debug.Log("Instantiated prefab: " + prefab.name);
        }
        else
        {
            Debug.LogError("Prefab not found at: " + prefabPath);
        }
        #else
        Debug.LogError("Instantiation only works in the Unity Editor");
        #endif
    }
}
