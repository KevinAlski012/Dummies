using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAdjustCollider : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private GameObject obj;

      private void Start()
      {
        // Debug.Log(platformCollider.size);
        RectTransform rt = obj.transform.GetComponent<RectTransform>();
        float width = rt.sizeDelta.x * rt.localScale.x;
        float height = rt.sizeDelta.y * rt.localScale.y;
        // Debug.Log(width);
        // Debug.Log(height);
        platformCollider.size = new Vector2(width, height-50);
      }
}
