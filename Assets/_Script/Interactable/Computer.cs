using System;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public static event Action onComputerOpen;
    public void Interact(PickUpLogic pickUpLogic)
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onComputerOpen?.Invoke();
    }
}
