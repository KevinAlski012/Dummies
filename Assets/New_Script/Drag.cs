using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public static Drag onDragLetter;
    [SerializeField] TMPro.TextMeshProUGUI displayLetter;
    // [SerializeField] TMPro.TMP_Text Text;
    [SerializeField] Inventory inventory;
    [SerializeField] string alpabeth;
    
    private bool clue, filled;
    private Vector3 firstPosition;
    private Transform firstParent;

    public string Letter { get; private set; }

    private void Awake() {
        // Debug.Log(alpabeth == null);
        // Debug.Log(displayLetter.text);

        if (alpabeth == "" || alpabeth == null)
        {
            alpabeth = displayLetter.text;
        }
    }
    
    public void Inisialisasi (Transform parent, string letter, bool clue)
    {
        Letter = letter;
        transform.SetParent(parent);
        displayLetter.SetText(Letter);
        this.clue = clue;
        GetComponent<CanvasGroup>().alpha = clue ? 0.5f : 1f;

    }

    public void Equal(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        clue = true;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (clue)
            return;
        
        firstPosition = transform.position;
        firstParent = transform.parent;
        onDragLetter = this;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (clue)
            return;

        transform.position = Input.mousePosition;

    }

    public void OnDrop(PointerEventData eventData)
    {
        // hanya akan jalan pada huruf yang merupkaan bagian dari clue
        if (clue && !filled)
        {
            
            if (onDragLetter.alpabeth == displayLetter.text)
            {
                WordManager.Instance.AddPoin();
                onDragLetter.Equal(transform);
                filled = true;
                GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (clue)
            return;

        onDragLetter = null;

        if (transform.parent == firstParent)
        {
            transform.position = firstPosition;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
