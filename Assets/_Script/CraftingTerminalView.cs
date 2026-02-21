using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Script
{
    public class CraftingTerminalView : View
    {
        public event Action PreviousClicked;
        public event Action NextClicked;
        public event Action CraftButtonClick;
        
        private Button _closeButton;
        private Button _craftButton;
        private Button _prevRecipe;
        private Button _nextRecipe;

        private Label _recipeName;
    
        private VisualElement _recipeContainer;
        [SerializeField] private VisualTreeAsset _inventoryRow;

        private void OnEnable()
        {
            CraftingTerminal.onCraftingTerminalOpen += Render;
        }

        private void OnDisable()
        {
            CraftingTerminal.onCraftingTerminalOpen -= Render;
        }

        private void Start()
        {
            
            Hide();
            _closeButton = ui.Q<Button>("CloseButton");
            _craftButton = ui.Q<Button>("CraftButton");
            _prevRecipe = ui.Q<Button>("PrevRecipe");
            _nextRecipe = ui.Q<Button>("NextRecipe");
            _recipeContainer = ui.Q<VisualElement>("RecipeContainer");
            _recipeName = ui.Q<Label>("RecipeName");
            _closeButton.clicked += OnClose;
            _prevRecipe.clicked += OnPreviousClick;
            _nextRecipe.clicked += OnNextClick;
            _craftButton.clicked += OnCraftButtonClick;
            
            CraftingTerminal.onCraftingTerminalOpen += Render;
        }

        private void Render(Recipe recipe)
        {
            _recipeContainer.Clear();
            _recipeName.text = recipe.name;
            foreach (var entry in recipe.recipeEntries)
            {
                VisualElement inventoryRow = _inventoryRow.CloneTree();
                Label ingredientNameLabel = inventoryRow.Q<Label>("InventoryLabel");
                Label ingredientAmountLabel = inventoryRow.Q<Label>("InventoryAmount");
                ingredientAmountLabel.text = entry.amount.ToString();
                ingredientNameLabel.text = entry.material.materialName;
                _recipeContainer.Add(inventoryRow);
            }
            DisableMovement();
            Show();
        }

        private void OnClose()
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
            UnityEngine.Cursor.visible = false;
            EnableMovement();
            Hide();
        }
        private void OnCraftButtonClick()
        {
            CraftButtonClick?.Invoke(); 
        }

        private void OnPreviousClick()
        {
            PreviousClicked?.Invoke();
            
        }

        private void OnNextClick()
        {
            NextClicked?.Invoke();
            
        }
    }   
}