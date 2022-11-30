using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueInteract : MonoBehaviour
{
    [SerializeField] Canvas textCanvas;
    [SerializeField] DialogueObject dialogueObject;
    [SerializeField] TMP_Text dialogueUserName;
    [SerializeField] TMP_Text dialogueText;

    [SerializeField] GameObject dialogueOptionsContainer;
    [SerializeField] Transform dialogueOptionsParent;
    [SerializeField] GameObject dialogueOptionsButtonPrefab;
    
    bool optionSelected = false;
    private int Count = 0;

    public void StartDialogue()
    {
        StartCoroutine(DisplayDialogue(dialogueObject));
    }

    public void StartDialogue(DialogueObject _dialogueObject)
    {
        StartCoroutine(DisplayDialogue(_dialogueObject));
    }

    public void OptionSelected(DialogueObject selectedOption) {
        optionSelected = true;
        dialogueObject = selectedOption;
        StartDialogue();
    }

    IEnumerator TypeSentence (string _dialogueText)
    {
        dialogueText.text = "";
        foreach (char letter in _dialogueText.ToCharArray())
        {
            Count++;
            Debug.Log(Count);
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("DONE");
		yield return null;
    }

    IEnumerator DisplayDialogue(DialogueObject _dialogueObject)
    {
        Debug.Log ("Start of Dialogue");
        yield return null;
        List<GameObject> spawnedButtons = new List<GameObject> ();

        textCanvas.enabled = true;
        foreach (var dialogue in _dialogueObject.dialogueSegments)
        {
            dialogueUserName.text = dialogue.dialogueUserName;
            //dialogueText.text = dialogue.dialogueText;
            StopCoroutine(TypeSentence(dialogue.dialogueText));
            
            Debug.Log("START");
            StartCoroutine(TypeSentence(dialogue.dialogueText));
            Count = 0;
            if (dialogue.dialogueChoices.Count == 0)
                yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
            else
            {
                dialogueOptionsContainer.SetActive(true);
                
                foreach (var option in dialogue.dialogueChoices)
                {
                    GameObject newButton = Instantiate (dialogueOptionsButtonPrefab, dialogueOptionsParent);
                    spawnedButtons.Add (newButton);
                    newButton.GetComponent<UIDialogueOption>().Setup (this, option.followOnDialogue, option.dialogueChoice);
                    //newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = option.dialogueChoice;
                }

                while (!optionSelected) 
                    yield return null;

                break;
            }
        }
        dialogueOptionsContainer.SetActive(false);
        textCanvas.enabled = false;
        optionSelected = false;
        
        spawnedButtons.ForEach (x => Destroy (x));
        Debug.Log ("End of Dialogue");
    }
}
