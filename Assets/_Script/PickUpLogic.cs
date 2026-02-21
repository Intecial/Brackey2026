
using _Script;
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
            if(equippedObject.TryGetComponent(out IPickUp pickUp))
            {
                pickUp.Drop();
            }
            equippedObject.transform.parent = null;
            equippedObject = null;
        }
    }

    public void UsePickUp(Transform facingTransform)
    {
        if(equippedObject != null)
        {
            if(equippedObject.TryGetComponent(out IPickUp pickUp))
            {
                pickUp.Use(facingTransform);
            }
        }
    }

    public void AlternateUsePickUp(Transform facingTransform)
    {
        if(equippedObject != null)
        {
            if(equippedObject.TryGetComponent(out IPickUp pickUp))
            {
                pickUp.AlternateUse(facingTransform);
            }
        }
    }

    public bool CompareRequirement(string requirement)
    {
        if (equippedObject != null)
        {
            if (equippedObject.TryGetComponent(out IObjective objective))
            {
                return objective.GetName() == requirement;
            }
        }

        return false;
    }

    public void DestroyPickedUp()
    {
        Destroy(equippedObject);
    }
}