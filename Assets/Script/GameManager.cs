using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] DialogueInteract introDialougeInteract;
    // Start is called before the first frame update
    void Start()
    {
        introDialougeInteract.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
