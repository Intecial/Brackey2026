using System;
using UnityEngine;
using UnityEngine.UIElements;

public class View : MonoBehaviour
{
    public static event Action OnDisableMovement;
    public static event Action OnEnableMovement;
    protected VisualElement ui;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    protected void DisableMovement()
    {
        OnDisableMovement?.Invoke();
    }

    protected void EnableMovement()
    {
        OnEnableMovement?.Invoke();
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