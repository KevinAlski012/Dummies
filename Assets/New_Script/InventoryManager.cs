using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake() 
    {
        Instance = this;
    }

    public void Add (Item item)
    {
        Items.Add(item);
    }

    public void Remove (Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            // TMPro.TextMeshProUGUI Alphabeth = ItemContent.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            // Debug.Log(Alphabeth);
            // Debug.Log(Item1.letter);

            // Alphabeth.SetText(item.letter);
            // var itemLetter = obj.transform.Find("Alphabeth").GetComponent<TMPro.TextMeshProUGUI>();

            // itemLetter = item.letter;

            
        }
    }
}
