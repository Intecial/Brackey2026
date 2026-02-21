using UnityEngine;
using UnityEngine.UIElements;

public class InventoryView : View
{
    private Button _closeButton;
    private VisualElement _inventoryContainer;
    [SerializeField] private VisualTreeAsset _inventoryRow;
    void OnEnable()
    {
        PlayerInventoryManager.onInventoryOpen += Render;
        _closeButton = ui.Q<Button>("CloseButton");
        _closeButton.clicked += OnClose;
        _inventoryContainer = ui.Q<VisualElement>("InventoryContainer");
    }

    private void Render(PlayerInventory inventory)
    {
        _inventoryContainer.Clear();
        foreach (InventoryEntry entry in inventory.materials)
        {
            VisualElement clonedRow = _inventoryRow.CloneTree();
            Label label = clonedRow.Q<Label>("InventoryLabel");
            Label amountLabel = clonedRow.Q<Label>("InventoryAmount");
            amountLabel.text = entry.amount.ToString();
            label.text = entry.material.name;
            _inventoryContainer.Add(clonedRow);
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
    void Start()
    {
        Hide();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
