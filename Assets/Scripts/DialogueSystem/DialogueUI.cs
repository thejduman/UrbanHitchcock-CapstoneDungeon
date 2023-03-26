using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text textLabel;    //reference to text label
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;
    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;
    public bool IsOpen { get; private set; }

    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

       

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);
            
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }

        
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text= string.Empty;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }*/
}
