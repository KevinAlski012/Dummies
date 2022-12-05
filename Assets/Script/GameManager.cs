using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadScene(string sceneName)
    {
        Debug.Log("Changing to Scene " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
