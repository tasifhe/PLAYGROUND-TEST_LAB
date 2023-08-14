using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _promt;
    public string InteractionPromt => "Open Chest";

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Open Chest");
        return true;
    }
}