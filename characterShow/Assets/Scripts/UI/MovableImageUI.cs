using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class MovableImageUI : MonoBehaviour ,  IDragHandler , IBeginDragHandler , IEndDragHandler
{
    
    public bool IsInTheField = false;
    public Vector3 StoredPosition;
    public bool IsOutOfBound = false;

    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData , bool> OnEndDragHandler;

    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        StoredPosition = new Vector3(100, 100, 0);
    }
    public bool CanDrag { get; set; } = true;

    public void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        OnDragHandler?.Invoke(eventData); //在drag之前會發生什麼是

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        OnBeginDragHandler?.Invoke(eventData);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (!CanDrag)
            return;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        DropField dropField = null;

        foreach (var result in results) 
        {
            dropField = result.gameObject.GetComponent<DropField>();
            if (dropField != null)
            {
                break;
            }
        }
        //找到dropField
        if (dropField != null) {
            if (dropField.Accepts(this))//確認可以放置物品
            {
                dropField.Drop(this); //開始放置
                OnEndDragHandler?.Invoke(eventData, true);//放置完後，需做的處理
                return;
            }
        }
        rectTransform.anchoredPosition = StoredPosition;
        OnEndDragHandler?.Invoke(eventData, false);

    }

}
