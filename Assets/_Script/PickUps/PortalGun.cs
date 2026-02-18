using System;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour, IPickUp
{

    public static event Action<string> OnAlternateClick;
    public List<string> portalGunSelections;
    private int selectedIndex = 0;
    [SerializeField]
    private GameObject portal;


    private GameObject spawnedPortal;
    
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
        Destroy(spawnedPortal);
        float distanceInFront = 3f;
        Vector3 calculatedSpawn =facingTransform.position + facingTransform.forward * distanceInFront;

        Vector3 flatForward = facingTransform.forward;
        flatForward.y = 0f;
        flatForward.Normalize();

        Quaternion lookRotation = Quaternion.LookRotation(flatForward);

        Quaternion yOffset = Quaternion.Euler(0f, 90f, 0f);

        Quaternion finalRotation = lookRotation * yOffset * portal.transform.rotation;

        GameObject portalClone = Instantiate(portal, calculatedSpawn, finalRotation);
        spawnedPortal = portalClone;
        portalClone.GetComponent<PortalController>().sceneName = portalGunSelections[selectedIndex];
    }

// Set alrtenate use to switch dimensions
    public void AlternateUse(Transform facingTransform)
    {
        selectedIndex = (selectedIndex + 1) % portalGunSelections.Count;
        OnAlternateClick?.Invoke(portalGunSelections[selectedIndex]);
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
