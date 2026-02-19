using System;
using System.Collections.Generic;
using _Script;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CraftingTerminal : MonoBehaviour, IInteractable
{
    public static event Action<Recipe, Transform> onCraft;
    public static event Action<Recipe> onCraftingTerminalOpen;
    public List<Recipe> recipes;
    public int currentIndex = 0;

    [SerializeField] private Transform spawnPoint;
    [SerializeField]
    private CraftingTerminalView craftingTerminalView;

    private void Awake()
    {
        craftingTerminalView.PreviousClicked += onPrevious;
        craftingTerminalView.NextClicked += onNext;
        craftingTerminalView.CraftButtonClick += CraftRecipe;

    }

    public void Interact()
    {
        currentIndex = 0;
        Recipe recipe = recipes[currentIndex % recipes.Count];
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onCraftingTerminalOpen?.Invoke(recipe);
    }
    
    private void onPrevious()
    {
        currentIndex--;
    }

    private void onNext()
    {
        currentIndex++;
    }

    private void CraftRecipe()
    {
        Recipe recipe = recipes[currentIndex % recipes.Count];
        Debug.Log(recipe.name + " :Crafting");
        onCraft?.Invoke(recipe, spawnPoint);
    }
    
    
}
