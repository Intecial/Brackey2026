using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public List<InventoryEntry> recipeEntries = new List<InventoryEntry>();
    public CraftMaterial material;
    public GameObject recipePrefab;
    public bool CraftRecipe(PlayerInventory inventory)
    {
        
        if (!inventory.HasMaterials(recipeEntries)) return false;
        foreach (var entry in recipeEntries)
        {
            inventory.UseMaterial(entry.material, entry.amount);
        }

        return true;
    }
}
