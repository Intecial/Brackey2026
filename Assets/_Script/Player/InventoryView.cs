using UnityEngine;
using UnityEngine.UIElements;

public class InventoryView : View
{
    private Button _closeButton;
    private VisualElement _inventoryContainer;
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
            Label label = new Label();
            label.text = entry.material.name + ": " + entry.amount;
            _inventoryContainer.Add(label);
        }
        Show();
    }

    private void OnClose()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = false;
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
