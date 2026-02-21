using System;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public static event Action<string> onInteract;
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask interactLayer;

    [Header("Keybind")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode pickUpKey = KeyCode.F;
    [SerializeField] private KeyCode dropKey = KeyCode.G;
    [SerializeField] private KeyCode useKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode alternateUseKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode portalGunKey = KeyCode.Z;

    private GameObject interactedObject;
    private GameObject hoveredPickUp;

    [SerializeField] private PickUpLogic pickUpLogic;
    // [SerializeField] private 
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
           interactedObject?.GetComponent<IInteractable>()?.Interact(pickUpLogic);
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
                onInteract?.Invoke("E");
            } else if (hit.collider.gameObject.TryGetComponent(out IPickUp pickUp))
            {
                hoveredPickUp = hit.collider.gameObject;
                onInteract?.Invoke("F");
            }
        }
        else
        {
            interactedObject = null; 
            onInteract?.Invoke("");
        }
    }

    void OnDrawGizmos(){ 
        Gizmos.color = Color.purple; 
        Gizmos.DrawRay(this.transform.position, this.transform.forward * interactRange); 
    }

}
