using UnityEngine;

public class Cronus : MonoBehaviour, IPickUp
{
    public void Drop()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    public void PickUp(PickUpLogic pickUpLogic)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = false;
        pickUpLogic.PickUpFlow(this.gameObject);
    }

    public void Use(Transform facingTransform)
    {
        // throw new System.NotImplementedException();
    }

    public void AlternateUse(Transform facingTransform)
    {
        // throw new System.NotImplementedException();
    }
}
