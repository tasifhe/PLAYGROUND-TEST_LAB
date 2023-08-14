using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PowerUp : MonoBehaviour
{   
    [SerializeField]
    private GameObject pickupEffect;
    [SerializeField]
    private float multiplier = 1.4f;
    [SerializeField]
    private float duration = 3f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (PickUp(other));
        }
    }
    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        _PlayerStats stats = player.GetComponent<_PlayerStats>();
        stats.health *= multiplier;

        player.transform.localScale *= multiplier;

        //* Disabling the powerup object
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;
        player.transform.localScale /= multiplier;
        
        Destroy(gameObject);
        Debug.Log("PowerUp");
    }
}
