using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class NPCDialogueView : View
{

    [SerializeField] private NPCController _npcController;
    public float dialogueSpeed;
    private Label _dialogueText;

    private VisualElement _buttonContainer;
    private Label _npcName;
    
    private void OnEnable()
    {
        _npcController.OnDialogueOpen += Render;
        _dialogueText = ui.Q<Label>("DialogueText");
        _buttonContainer = ui.Q<VisualElement>("ChoiceContainer");
        _npcName = ui.Q<Label>("NPCName");
    }

    private void OnDisable()
    {
        _npcController.OnDialogueOpen -= Render;
    }
    private void Render(NPCDialogues dialogues)
    {
        _npcName.text = dialogues.npcName;
        StartCoroutine(ExecuteDialogue(dialogues.dialogues));

        Button waitButton = new Button();
        waitButton.text = "Please Wait";
        waitButton.clicked += OnClose;
        
        Button submitButton = new Button();
        submitButton.text = "Submit";
        submitButton.clicked += OnClose;
        submitButton.clicked += _npcController.SubmitButtonClicked;
        
        _buttonContainer.Clear();
        _buttonContainer.Add(waitButton);
        _buttonContainer.Add(submitButton);
        DisableMovement();
        Show();
    }
    
    private IEnumerator ExecuteDialogue(List<string> executedDialog)
    {
        foreach (var dialogue in executedDialog)
        {
            _dialogueText.text = dialogue;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        yield return new WaitForSeconds(dialogueSpeed);
    }
    private void OnClose()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = false;
        EnableMovement();
        Hide();
    }

    private void Start()
    {
        Hide();
    }
}
