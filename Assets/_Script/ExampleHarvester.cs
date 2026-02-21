using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExampleHarvester : MonoBehaviour, IInteractable
{
    [SerializeField]
    private CraftMaterial materialToDrop;

    public int maxAmount;
    private bool _isHarvested = false;

    public static event Action<CraftMaterial, int> onHarvest;

    public GameObject itemToDestroy;
    
    public void Interact(PickUpLogic pickUpLogic)
    {
        if (_isHarvested) return;
        int amountToDrop = Random.Range(1, maxAmount);
        onHarvest?.Invoke(materialToDrop, amountToDrop);
        itemToDestroy.SetActive(false);
        _isHarvested = true;
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
