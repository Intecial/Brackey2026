using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalGunToolTip : View
{
    private Label dimensionLabel;
        void OnEnable()
    {
        PortalGun.OnAlternateClick += ChangeDimension;
        dimensionLabel = ui.Q<Label>("PortalLevelName");
    }

    void OnDisable()
    {
        RaycastHandler.onInteract -= ChangeDimension;
    }
    

    private void ChangeDimension(string dimension)
    {
        dimensionLabel.text = dimension;
        Show();
        StartCoroutine(DelayHide());
    }

    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(1.5f);
        Hide();
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
