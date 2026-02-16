using UnityEngine;

public class InteractToolTip : View
{

    void OnEnable()
    {
        RaycastHandler.onInteract += onInteractHover;
    }

    void OnDisable()
    {
        RaycastHandler.onInteract -= onInteractHover;
    }

    private void onInteractHover(bool hasInteractObject)
    {
        if (hasInteractObject)
        {
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
