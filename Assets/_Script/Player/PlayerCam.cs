using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;
    private bool _isInputDisabled = false;
    public Transform orientation;

    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        View.OnDisableMovement += DisableInput;
        View.OnEnableMovement += EnableInput;
    }

    private void OnDisable()
    {
        View.OnDisableMovement -= DisableInput;
        View.OnEnableMovement -= EnableInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInputDisabled) return;
        Vector2 mouse = Mouse.current.delta.ReadValue();

        float mouseX = mouse.x * Time.deltaTime * sensX;
        float mouseY = mouse.y * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void DisableInput()
    {
        _isInputDisabled = true;
    }

    void EnableInput()
    {
        _isInputDisabled = false;
    }
}
