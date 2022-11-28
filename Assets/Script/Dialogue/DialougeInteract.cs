using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeInteract : MonoBehaviour
{
    [SerializeField] Canvas textCanvas;
    [SerializeField] DialogueObject dialogueObject;
    [SerializeField] TMP_Text dialogueUserName;
    [SerializeField] TMP_Text dialogueText;

    [SerializeField] GameObject dialogueOptionsContainer;
    [SerializeField] GameObject dialogueOptionsParent;
    [SerializeField] GameObject dialogueOptionsButtonPrefab;
    
    public void StartDialogue ()
    {
        textCanvas.enabled = false;
        StartCoroutine (DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        textCanvas.enabled = true;
        foreach (var dialogue in dialogueObject.dialogueSegments)
        {
            dialogueUserName.text = dialogue.dialogueUserName;
            dialogueText.text = dialogue.dialogueText;
            if (dialogue.dialogueChoices.Count == 0)
                yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
            else
            {
                yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
            }
        }
        textCanvas.enabled = false;
    }
}
