using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isPlayerInRange;

    public void TriggerDialogue()
    {
        // Debug.Log("TriggerDialogue");
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
    /*void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTrxit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }*/
}
