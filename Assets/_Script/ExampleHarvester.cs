using System;
using UnityEngine;

public class ExampleHarvester : MonoBehaviour, IInteractable
{
    [SerializeField]
    private CraftMaterial materialToDrop;

    public static event Action<CraftMaterial, int> onHarvest;
    
    public void Interact()
    {
        onHarvest?.Invoke(materialToDrop, 1);
        Debug.Log("Get Item");  
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
