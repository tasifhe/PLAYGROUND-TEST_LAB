using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactionMask;
    [SerializeField] private InteractionPromtUI _interactionPromtUI;

    private readonly Collider[] _colliders = new Collider[10];
    [SerializeField] private int _colliderCount;

    private IInteractable _interactable;

    private void Update()
    {
        _colliderCount = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders, _interactionMask);

        if(_colliderCount > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if(_interactable != null)
            {
                if(!_interactionPromtUI.IsDisplayed) _interactionPromtUI.SetUp(_interactable.InteractionPromt);

                if(Keyboard.current.eKey.wasPressedThisFrame)
                {
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            if(_interactable != null) _interactable = null;

            if (_interactionPromtUI.IsDisplayed) _interactionPromtUI.Close();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
    }
}
