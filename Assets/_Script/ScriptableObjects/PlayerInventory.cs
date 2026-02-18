using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryEntry
{
    public CraftMaterial material;
    public int amount;
}
[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Scriptable Objects/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryEntry> materials = new List<InventoryEntry>();
}