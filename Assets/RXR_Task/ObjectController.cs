//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class ObjectController : MonoBehaviour
//{
//    public float rayLength;
//    [SerializeField] LayerMask layerMask;

//    private void Update()
//    {
//        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
//        {
//            ObjectSelector();
//        }
//    }
//    public void ObjectSelector()
//    {
//        RaycastHit hit;
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        if(Physics.Raycast(ray, out hit, rayLength, layerMask))
//        {
//            Debug.Log("Hit object: " + hit.collider.gameObject.name);
//            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
//        }
//        else
//        {
//            Debug.Log("No object hit");
//            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);
//        }
//    }
//}
