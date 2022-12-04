using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance { get; private set; } 

    [SerializeField] Drag letterPrefab;
    [SerializeField] Transform firstSlot, lastSLot;
    [SerializeField] string[] wordsList;

    private int wordPoin, poin;
    private int numberWord = 0;
    
    void Start()
    {
        Instance = this;

        WordInit(wordsList[numberWord]);
    }

    void WordInit (string word)
    {
        char[] wordLetter = word.ToCharArray();
        char[] randomLetter = new char[wordLetter.Length];

        List<char> wordLetterCopy = new List<char>();
        wordLetterCopy = wordLetter.ToList();
        
        for (int i = 0; i < randomLetter.Length; i++)
        {
            int randomIndex = Random.Range (0, wordLetterCopy.Count);
            randomLetter[i] = wordLetterCopy[randomIndex];
            wordLetterCopy.RemoveAt(randomIndex);

            Drag temp = Instantiate(letterPrefab, firstSlot);

            temp.Inisialisasi(firstSlot, randomLetter[i].ToString(), false);
        }

        for (int i = 0; i < wordLetter.Length; i++)
        {
            Drag temp = Instantiate(letterPrefab, lastSLot);

            temp.Inisialisasi(lastSLot, wordLetter[i].ToString(), true);
        }

        wordPoin = wordLetter.Length;
        Debug.Log(wordLetter.Length);
        // Debug.Log(randomLetter[0]);
        // Debug.Log(wordLetterCopy[0]);

    }

    public void AddPoin()
    {
        poin++;

        if (poin == wordPoin)
        {
            Debug.Log("Susunan Berhasil");
            numberWord += 1;
            foreach (Transform child in lastSLot)
            {
                Destroy(child.gameObject);
            }
            // Debug.Log(wordPoin);
            WordInit(wordsList[numberWord]);
        }
    }
}
