using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance { get; private set; } 

    [SerializeField] Drag letterPrefab;
    [SerializeField] Transform firstSlot, lastSLot;
    [SerializeField] string[] wordsList;
    [SerializeField] string[] questions;
    [SerializeField] TMPro.TextMeshProUGUI questionPrefab ;

    [SerializeField] Transform questionsPosition;

    [SerializeField] Button button;

    private int wordPoin, poin;
    private int numberWord = 0;
    
    void Start()
    {
        Instance = this;
        // Debug.Log(questions);
        WordInit(wordsList[numberWord]);
        QuestionInit(questions[numberWord]);
    }

    void WordInit (string word)
    {
        char[] wordLetter = word.ToCharArray();
        char[] randomLetter = new char[wordLetter.Length];

        List<char> wordLetterCopy = new List<char>();
        wordLetterCopy = wordLetter.ToList();
        
        // for (int i = 0; i < randomLetter.Length; i++)
        // {
        //     int randomIndex = Random.Range (0, wordLetterCopy.Count);
        //     randomLetter[i] = wordLetterCopy[randomIndex];
        //     wordLetterCopy.RemoveAt(randomIndex);

        //     Drag temp = Instantiate(letterPrefab, firstSlot);

        //     temp.Inisialisasi(firstSlot, randomLetter[i].ToString(), false);
        // }


        // InventoryUI invenUI[] = gameObject.GetComponentsInChildren<Drag>();
        // Debug.Log(InventoryUI.)

        for (int i = 0; i < wordLetter.Length; i++)
        {
            Drag temp = Instantiate(letterPrefab, lastSLot);

            temp.Inisialisasi(lastSLot, wordLetter[i].ToString(), true);
        }

        wordPoin = wordLetter.Length;
        // Debug.Log(wordLetter.Length);
        // Debug.Log(randomLetter[0]);
        // Debug.Log(wordLetterCopy[0]);

    }

    void QuestionInit(string question)
    {
        var temp = Instantiate(questionPrefab, questionsPosition);
        temp.SetText(question);
        Debug.Log(question);
        // Debug.Log(question);


        // temp.Inisialisasi(lastSLot, wordLetter[i].ToString(), true);
    }

    public void AddPoin()
    {
        poin++;

        if (poin == wordPoin)
        {
            Debug.Log("Susunan Berhasil");
            poin = 0;
            numberWord += 1;
            foreach (Transform child in lastSLot)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in questionsPosition)
            {
                // Debug.Log(child);
                Destroy(child.gameObject);
            }
            // Debug.Log(wordPoin);
            // WordInit(wordsList[numberWord]);
            // QuestionInit(questions[numberWord]);
            button.gameObject.SetActive(true);

        }
    }
}
