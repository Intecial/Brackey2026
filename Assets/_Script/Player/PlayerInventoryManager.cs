using System;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{

    public static event Action<PlayerInventory> onInventoryOpen;
    
    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _playerInventory = new PlayerInventory();
    }

    public void OnEnable()
    {
        ExampleHarvester.onHarvest += AddMaterial;
        Computer.onComputerOpen += OpenInventory;
        CraftingTerminal.onCraft += CraftRecipe;
    }
    public void OnDisable()
    {
        ExampleHarvester.onHarvest -= AddMaterial;
        Computer.onComputerOpen -= OpenInventory;   
        CraftingTerminal.onCraft -= CraftRecipe;
    }

    private void AddMaterial(CraftMaterial material, int amount)
    {

        _playerInventory.AddMaterial(material, amount);
    }

    public bool UseMaterial(CraftMaterial material, int amount)
    {
        return _playerInventory.UseMaterial(material, amount);
    }

    private void OpenInventory()
    {
        onInventoryOpen?.Invoke(_playerInventory);
    }

    private void CraftRecipe(Recipe recipe, Transform spawnLocation)
    {
        if (recipe.CraftRecipe(_playerInventory))
        {
            Instantiate(recipe.recipePrefab, spawnLocation.position, spawnLocation.rotation);
            // _playerInventory.AddMaterial(recipe.material, 1);
        }
    }
}
