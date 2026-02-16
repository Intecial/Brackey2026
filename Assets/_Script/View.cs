using UnityEngine;
using UnityEngine.UIElements;

public class View : MonoBehaviour
{
    protected VisualElement ui;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    protected void Show()
    {
        ui.style.display = DisplayStyle.Flex;
    }

    protected void Hide()
    {
        ui.style.display = DisplayStyle.None;
    }
}