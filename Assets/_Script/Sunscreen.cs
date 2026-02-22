using _Script;
using UnityEngine;

public class Sunscreen : MonoBehaviour, IPickUp, IObjective
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(PickUpLogic pickUpLogic)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = false;
        pickUpLogic.PickUpFlow(this.gameObject);
    }

    public void Drop()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    public void Use(Transform facingTransform)
    {
        // throw new System.NotImplementedException();
    }

    public void AlternateUse(Transform facingTransform)
    {
        // throw new System.NotImplementedException();
    }

    public string GetName()
    {
        return "Sunscreen";
    }
}
