

using UnityEngine;

public interface IPickUp
{
    void PickUp(PickUpLogic pickUpLogic);
    void Drop();

    void Use(Transform facingTransform);

    void AlternateUse(Transform facingTransform);
}