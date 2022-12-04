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
    [SerializeField] Button nextButton;

    [SerializeField] GameObject dialogueOptionsContainer;
    [SerializeField] Transform dialogueOptionsParent;
    [SerializeField] GameObject dialogueOptionsButtonPrefab;
    
    bool optionSelected = false;
    private int Count = 0;
    private Queue<string> dialogueSentences;
    private Queue<string> dialogueName;
    DialogueObject newDialogueObject;
    List<GameObject> spawnedButtons = new List<GameObject> ();

    public void StartDialogue()
    {
		StopAllCoroutines();
        dialogueSentences = new Queue<string>();
        dialogueName = new Queue<string>();
        DisplayDialogue(dialogueObject);
    }

    public void StartDialogue(DialogueObject _dialogueObject)
    {
		StopAllCoroutines();
        dialogueSentences = new Queue<string>();
        dialogueName = new Queue<string>();
        DisplayDialogue(_dialogueObject);
    }

    public void EndDialogue()
    {
        nextButton.onClick.RemoveListener(DisplayNextSentence);
        dialogueOptionsContainer.SetActive(false);
        textCanvas.enabled = false;
        optionSelected = false;
        
        spawnedButtons.ForEach (x => Destroy (x));
        
        Debug.Log ("End of Dialogue");
    }

    public void OptionSelected(DialogueObject selectedOption) {
        optionSelected = true;
        dialogueObject = selectedOption;
        EndDialogue();
        StartDialogue();
    }

    IEnumerator TypeSentence(string _dialogueText, Action action, Action action2 )
    {
        dialogueText.text = "";
        foreach (char letter in _dialogueText.ToCharArray())
        {
            Count++;
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        Count = 0;
        action();
        action2();
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
        nextButton.onClick.AddListener(DisplayNextSentence);
        dialogueSentences.Clear();
        dialogueName.Clear();
        newDialogueObject = _dialogueObject;
        Debug.Log (dialogueSentences.Count);
        Debug.Log ("Start of Dialogue");

        textCanvas.enabled = true;
        foreach (var dialogue in _dialogueObject.dialogueSegments)
        {
            dialogueSentences.Enqueue(dialogue.dialogueText);
            dialogueName.Enqueue(dialogue.dialogueUserName);
        }
        Debug.Log("Display Text Count : " + dialogueSentences.Count);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        nextButton.gameObject.SetActive(false);
        dialogueOptionsContainer.SetActive(false);
        Debug.Log("Next Text : " + dialogueSentences.Count);
        if (dialogueSentences.Count == 0)
		{
            newDialogueObject = null;
            Debug.Log ("End of Dialogue");
			EndDialogue();
			return;
		}
        string sentence = dialogueSentences.Dequeue();
        string name = dialogueName.Dequeue();
        dialogueUserName.text = name;
        Debug.Log("Latest Text : " + sentence);
		StopAllCoroutines();
        Action displayChoiceAction = () => DisplayChoices(sentence);
		StartCoroutine(TypeSentence(sentence, NextButtonAppear, displayChoiceAction));
    }

    public void NextButtonAppear()
    {
        nextButton.gameObject.SetActive(true);
    }

    private void DisplayChoices(String sentence)
    {
        Debug.Log("Latest newDialogueObject : " + newDialogueObject.dialogueSegments.Count);
        foreach(var dialogue in newDialogueObject.dialogueSegments)
        {
            if(sentence == dialogue.dialogueText)
            {
                if(dialogue.dialogueChoices.Count > 0)
                {
                    nextButton.gameObject.SetActive(false);
                    dialogueOptionsContainer.SetActive(true);
                    foreach (var option in dialogue.dialogueChoices)
                    {
                        GameObject newButton = Instantiate (dialogueOptionsButtonPrefab, dialogueOptionsParent);
                        spawnedButtons.Add (newButton);
                        newButton.GetComponent<UIDialogueOption>().Setup (this, option.followOnDialogue, option.dialogueChoice);
                    }   
                }
            }
            
            while (!optionSelected) 
            
            
            break;
        }
    }
}
