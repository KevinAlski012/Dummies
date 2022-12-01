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
    private Queue<string> dialogueSentences;
    DialogueObject newDialogueObject;
    List<GameObject> spawnedButtons = new List<GameObject> ();

    public void StartDialogue()
    {
        dialogueSentences = new Queue<string>();
        DisplayDialogue(dialogueObject);
    }

    public void StartDialogue(DialogueObject _dialogueObject)
    {
        dialogueSentences = new Queue<string>();
        DisplayDialogue(_dialogueObject);
    }

    public void EndDialogue()
    {
        dialogueOptionsContainer.SetActive(false);
        textCanvas.enabled = false;
        optionSelected = false;
        
        spawnedButtons.ForEach (x => Destroy (x));
        
        Debug.Log ("End of Dialogue");
    }

    public void OptionSelected(DialogueObject selectedOption) {
        optionSelected = true;
        dialogueObject = selectedOption;
        StartDialogue();
    }

    IEnumerator TypeSentence(string _dialogueText)
    {
        dialogueText.text = "";
        foreach (char letter in _dialogueText.ToCharArray())
        {
            Count++;
            //Debug.Log(Count);
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        Count = 0;
		yield return null;
    }

    IEnumerator TypeSentence2(string _dialogueText)
    {
        dialogueText.text = "";
        Count = 0;
        while (Count < _dialogueText.Length)
        {
            Count++;
            //Debug.Log(Count);
            dialogueText.text = _dialogueText.Substring(0, Count);
            yield return new WaitForSeconds(0.1f);
        }
		yield return null;
    }

    // IEnumerator DisplayDialogue(DialogueObject _dialogueObject)
    // {
    //     Debug.Log ("Start of Dialogue");
    //     yield return null;
    //     List<GameObject> spawnedButtons = new List<GameObject> ();

    //     textCanvas.enabled = true;
    //     foreach (var dialogue in _dialogueObject.dialogueSegments)
    //     {
    //         dialogueUserName.text = dialogue.dialogueUserName;
    //         //dialogueText.text = dialogue.dialogueText;
    //         StopCoroutine(TypeSentence2(dialogue.dialogueText));
            
    //         Debug.Log("START");
    //         StartCoroutine(TypeSentence(dialogue.dialogueText));
    //         if (dialogue.dialogueChoices.Count == 0)
    //             yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
    //         else
    //         {
    //             dialogueOptionsContainer.SetActive(true);
                
    //             foreach (var option in dialogue.dialogueChoices)
    //             {
    //                 GameObject newButton = Instantiate (dialogueOptionsButtonPrefab, dialogueOptionsParent);
    //                 spawnedButtons.Add (newButton);
    //                 newButton.GetComponent<UIDialogueOption>().Setup (this, option.followOnDialogue, option.dialogueChoice);
    //             }

                // while (!optionSelected) 
                //     yield return null;

                // break;
    //         }
    //     }
    //     dialogueOptionsContainer.SetActive(false);
    //     textCanvas.enabled = false;
    //     optionSelected = false;
        
    //     spawnedButtons.ForEach (x => Destroy (x));
    //     Debug.Log ("End of Dialogue");
    // }

    public void DisplayDialogue(DialogueObject _dialogueObject)
    {
        dialogueSentences.Clear();
        newDialogueObject = _dialogueObject;
        Debug.Log ("Start of Dialogue");

        textCanvas.enabled = true;
        foreach (var dialogue in _dialogueObject.dialogueSegments)
        {
            dialogueSentences.Enqueue(dialogue.dialogueText);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueSentences.Count == 0)
		{
            newDialogueObject = null;
            Debug.Log ("End of Dialogue");
			EndDialogue();
			return;
		}
        string sentence = dialogueSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
        DisplayChoices(sentence);
    }

    private void DisplayChoices(String sentence)
    {
        foreach(var dialogue in newDialogueObject.dialogueSegments)
        {
            Debug.Log("Start : " + dialogue.dialogueText);
            if(sentence == dialogue.dialogueText)
            {
                dialogueOptionsContainer.SetActive(true);
                foreach (var option in dialogue.dialogueChoices)
                {
                    GameObject newButton = Instantiate (dialogueOptionsButtonPrefab, dialogueOptionsParent);
                    spawnedButtons.Add (newButton);
                    newButton.GetComponent<UIDialogueOption>().Setup (this, option.followOnDialogue, option.dialogueChoice);
                }
            }
            else
                return;
            
            while (!optionSelected) 
            
            Debug.Log("End : " + dialogue.dialogueText);
            break;
        }
    }
}
