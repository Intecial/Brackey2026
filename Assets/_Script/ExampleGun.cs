using UnityEngine;

public class ExampleGun : MonoBehaviour, IPickUp
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Drop(PickUpLogic pickUpLogic)
    {
       Rigidbody rb = GetComponent<Rigidbody>();
       rb.isKinematic = false;
       rb.detectCollisions = true;
       pickUpLogic.DropFlow();
    }

    public void PickUp(PickUpLogic pickUpLogic)
    {
       Rigidbody rb = GetComponent<Rigidbody>();
       rb.isKinematic = true;
       rb.detectCollisions = false;
       pickUpLogic.PickUpFlow(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
