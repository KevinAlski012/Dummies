using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Transform inventoryParent;
    [SerializeField] int numOfSlot;

    List<RectTransform> slots = new List<RectTransform>();



    private void Start() {
        // BuildSlots();
        // PutItems();
        inventory.OnMemberChanged += PutItems;
    }

    public void BuildSlots()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (var trans in children)
        {
            if (trans == this.transform)
            {
                continue;
            }
            Destroy(trans.gameObject);
        }

        slots.Clear();
        for (int i = 0; i < numOfSlot; i++)
        {
            var slot = Instantiate(slotPrefab, this.transform);
            // var slot = Instantiate(slotPrefab, inventoryParent);
            slots.Add(slot.GetComponent<RectTransform>());
        }
    }

    public void PutItems()
    {
        
        var emptySlots = numOfSlot;
        foreach (var item in inventory.Items)
        {
            item.gameObject.SetActive(true);
            item.SpriteRenderer.transform.SetParent(inventoryParent);
            // item.SpriteRenderer.gameObject.SetActive(true);
            // Collider2D itemCollider =  item.SpriteRenderer.GetComponentInChildren<Collider2D>();
            // itemCollider.enabled = !itemCollider.enabled;
            
            // if (emptySlots != 0)
            // {
            //     item.gameObject.SetActive(true);
            //     item.SpriteRenderer.transform.SetParent(inventoryParent);
            //     // item.SpriteRenderer.gameObject.SetActive(true);
            //     Collider2D itemCollider =  item.SpriteRenderer.GetComponentInChildren<Collider2D>();
            //     itemCollider.enabled = !itemCollider.enabled;
            //     // item.Image.transform.SetParent(slots[numOfSlot - emptySlots]);
            //     // item.Image.transform.localPosition =  Vector2.zero;
            //     emptySlots -= 1; 
            // }
            // else
            // {
            //     item.gameObject.SetActive(false);
            // }
        }
    }
}
