using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public event Action OnCompleteRequest;

    public event Action<NPCDialogues> OnDialogueOpen;
    [SerializeField]
    private NPCDialogueView _dialogueView;

    [SerializeField]
    private NPCDialogues dialogues;

    private bool isTalking = false;
    private PickUpLogic storedPickUp;
    
    public void Interact(PickUpLogic pickUpLogic)
    {
        if(isTalking) return;
        storedPickUp = pickUpLogic;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        OnDialogueOpen?.Invoke(dialogues);
    }

    private IEnumerator DespawnNpc()
    {
        
        yield return new WaitForSeconds(3f);
        OnCompleteRequest?.Invoke();
        Destroy(this.gameObject);
    }

    public void SubmitButtonClicked()
    {
        if (storedPickUp.CompareRequirement(dialogues.requirement))
        {   
            
            storedPickUp.DestroyPickedUp();
            StartCoroutine(DespawnNpc());
        }
        
    }
    
}
