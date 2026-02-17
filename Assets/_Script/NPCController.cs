using System.Collections;
using TMPro;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TextMeshPro dialogText;
    public float dialogueSpeed;

    [SerializeField]
    private NPCDialogues dialogues;

    private bool isTalking = false;

    public void Interact()
    {
        if(isTalking) return;
        StartCoroutine(ExecuteDialogue());
    }

    private IEnumerator ExecuteDialogue()
    {
        isTalking = true;
        foreach (var dialogue in dialogues.dialogues)
        {
            dialogText.text = dialogue;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        yield return new WaitForSeconds(dialogueSpeed);
        isTalking = false;
        dialogText.text = "";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
