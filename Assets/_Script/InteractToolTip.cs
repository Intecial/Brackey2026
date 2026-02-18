using UnityEngine;
using UnityEngine.UIElements;

public class InteractToolTip : View
{

    private Label labelText;
    void OnEnable()
    {
        RaycastHandler.onInteract += onInteractHover;
        labelText = ui.Q<Label>("InteractText");
    }

    void OnDisable()
    {
        RaycastHandler.onInteract -= onInteractHover;
    }

    private void onInteractHover(string hasInteractObject)
    {
        labelText = ui.Q<Label>("InteractText");
        if (hasInteractObject != "")
        {
            labelText.text = "Press [ " + hasInteractObject + " ] to interact";
            Show();
        } else
        {
            Hide();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
