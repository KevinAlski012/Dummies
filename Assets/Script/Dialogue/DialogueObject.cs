using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogueObject", menuName = "NPC Dialogue Object", order = 0)]
public class DialogueObject : ScriptableObject
{
    [Header ("Dialougue")]
    public List<DialogueSegment> dialogueSegments = new List<DialogueSegment>();
}

[System.Serializable]
public struct DialogueSegment
{
    public string dialogueUserName;
    public string dialogueText;
    public float dialogueDisplayTime;
    public List<DialogueChoice> dialogueChoices;
}

[System.Serializable]
public struct DialogueChoice
{
    public string dialogueChoice;
    public DialogueObject followOnDialogue;
}