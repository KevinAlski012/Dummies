using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject worldObject;
    [SerializeField] GameObject UIObject;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] Image spriteRenderer;
    [SerializeField] Image image;
    [SerializeField] bool isInInventory;

    public bool IsInInventory { 
        get => isInInventory; 
        set{ 
            isInInventory = value;
            worldObject.SetActive(!isInInventory);
            UIObject.SetActive(isInInventory);
        }}

    public Image Image { get => image; }
    public Image SpriteRenderer { get => spriteRenderer; }

    private void Awake() {
        IsInInventory = isInInventory;
    }

    public void Act(Interactor interactor)
    {
        var inventoryComponent = interactor.GetComponent<InventoryComponent>();
        inventoryComponent.Inventory.Add(this);
        IsInInventory = true;
        inventoryUI.PutItems();
        // Destroy(this.gameObject);
    }

    public void Focused(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    public void UnFocused(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }
}
