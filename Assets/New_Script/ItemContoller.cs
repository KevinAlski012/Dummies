using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContoller : MonoBehaviour
{
    // public Item Item;

    [SerializeField] TMPro.TextMeshProUGUI displayLetter;
    [SerializeField] string alphabeth;

    private void Start() {
        displayLetter.SetText(alphabeth);
    }
}
