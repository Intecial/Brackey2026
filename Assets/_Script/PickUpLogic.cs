
using UnityEngine;

public class PickUpLogic : MonoBehaviour
{
    [SerializeField] private Transform equippedLocation;

    private GameObject equippedObject = null;
    public void PickUpFlow(GameObject pickUpObject)
    {
        if(pickUpObject.TryGetComponent(out IPickUp pickUp))
        {
            equippedObject = pickUpObject;
            pickUpObject.transform.parent = equippedLocation;
            pickUpObject.transform.localPosition = Vector3.zero;
            pickUpObject.transform.localRotation = Quaternion.identity;
        }
    }

    public void DropFlow()
    {
        if(equippedObject != null)
        {
            equippedObject.transform.parent = null;
            equippedObject = null;
        }
    }
}