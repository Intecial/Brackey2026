using System;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public static event Action<bool> onInteract;
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask interactLayer;

    [Header("Keybind")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode pickUpKey = KeyCode.F;
    [SerializeField] private KeyCode dropKey = KeyCode.G;
    [SerializeField] private KeyCode useKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode alternateUseKey = KeyCode.Mouse1;

    private GameObject interactedObject;
    private GameObject hoveredPickUp;

    [SerializeField] private PickUpLogic pickUpLogic;

    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        
    }

    private void HandleInput()
    {
        CheckInteractable();
        if(Input.GetKeyDown(interactKey))
        {
           interactedObject?.GetComponent<IInteractable>()?.Interact();
        }
        if (Input.GetKeyDown(pickUpKey))
        {
            hoveredPickUp?.GetComponent<IPickUp>()?.PickUp(pickUpLogic);
        }
        if (Input.GetKeyDown(dropKey))
        {
            pickUpLogic.DropFlow();
            // hoveredPickUp?.GetComponent<IPickUp>()?.Drop(pickUpLogic);
        }
        if (Input.GetKeyDown(useKey))
        {
            pickUpLogic.UsePickUp(this.transform);   
        }
        if (Input.GetKeyDown(alternateUseKey))
        {
            pickUpLogic.AlternateUsePickUp(this.transform);
        }
    }

    private void CheckInteractable()
    {
        Ray r = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(r, out RaycastHit hit, interactRange, interactLayer))
        {
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactedObject = hit.collider.gameObject;
                onInteract?.Invoke(true);
            } else if (hit.collider.gameObject.TryGetComponent(out IPickUp pickUp))
            {
                hoveredPickUp = hit.collider.gameObject;
                onInteract?.Invoke(true);
            }
        }else
            {
                interactedObject = null;
                onInteract?.Invoke(false);
            }
    }

    void OnDrawGizmos(){ 
        Gizmos.color = Color.purple; 
        Gizmos.DrawRay(this.transform.position, this.transform.forward * interactRange); 
    }

}
