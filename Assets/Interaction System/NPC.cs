using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string _promt;
    public string InteractionPromt => "Press E Talk";

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk!!");
        return true;
    }
}