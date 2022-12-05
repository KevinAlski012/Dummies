using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName="Custom Assets/New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] List<Item> items = new List<Item>();

    public List<Item> Items { get => items; }

    public event Action OnMemberChanged;
    
    public void Add(Item item)
    {
        items.Add(item);
        OnMemberChanged?.Invoke();
    }

    public void Remove (Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            OnMemberChanged?.Invoke();
        }
    }

    public void Clear()
    {
        items.Clear();
    }
}
