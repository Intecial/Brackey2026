using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryEntry
{
    public CraftMaterial material;
    public int amount;
}
public class PlayerInventory
{
    public readonly List<InventoryEntry> materials;

    public PlayerInventory()
    {
        materials = new List<InventoryEntry>();
    }

    public bool HasMaterials(List<InventoryEntry> amounts)
    {
        foreach (var entry in amounts)
        {
            InventoryEntry found =  materials.Find(x => x.material == entry.material);
            if (found == null || found.amount < entry.amount)
            {
                return false;
            }
        }

        return true;
    }

    public bool AddMaterial(CraftMaterial material, int amount)
    {
        foreach (InventoryEntry entry in materials)
        {
            if (entry.material == material)
            {
                entry.amount += amount;
                return true;
            }
        }
        materials.Add(new InventoryEntry { material = material, amount = amount });
        return true;
    }

    public bool UseMaterial(CraftMaterial material, int amount)
    {
        foreach (InventoryEntry entry in materials)
        {
            if (entry.material == material && entry.amount >= amount)
            {
                entry.amount -= amount;
                return true;
            }
        }
        return false;
    }
}