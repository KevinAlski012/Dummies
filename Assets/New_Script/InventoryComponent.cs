using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    public Inventory Inventory { get => inventory; }

    private void Awake() {
        inventory.Clear();
    }
}
