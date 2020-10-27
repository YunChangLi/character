using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public abstract class MovableImageUI : MonoBehaviour ,  IDragHandler , IBeginDragHandler , IEndDragHandler
{
    
    public bool IsOutOfBound = false;
    public bool IsNotReturn = false;
    public Vector3 StoredPosition; //紀錄所屬位置
    public DropField ItemField; //紀錄所屬欄位

    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData , bool> OnEndDragHandler;

    protected RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        UIInitialized();
    }
    public virtual void UIInitialized()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    public bool CanDrag { get; set; } = true;

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            Debug.Log("Cannot Drag");
            return;
        }
        Debug.Log("Can Drag");
        OnDragHandler?.Invoke(eventData); //在drag之前會發生什麼是

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            Debug.Log("Cannot Begin Drag");
            return;
        }
        Debug.Log("Can Begin Drag");
        OnBeginDragHandler?.Invoke(eventData);
    }


    public virtual void OnEndDrag(PointerEventData eventData)
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
            if (dropField == ItemField) //無拉出框內保留原地
            {
                this.transform.position = ItemField.transform.position;
                return;
            }
            if (dropField.Accepts(this))//確認可以放置物品
            {
                if (dropField.GetDropItem() != null) //如果欄位上已有物品
                {
                    MoveItemToFilledField(dropField.GetDropItem(), this);
                }

                dropField.Drop(this); //開始放置
                OnEndDragHandler?.Invoke(eventData, true);//放置完後，需做的處理

                if (ItemField != null) //從一個欄位移到另一個欄位
                {
                    //將之前欄位的紀錄清空
                    realeseField(ItemField);
                    Destroy(this.gameObject);

                }
                return;

            }

        }
        else 
        {
            if (ItemField != null) //將物件拉離欄位
            {
                realeseField(ItemField);//物件離開欄位 釋放ItemField
                Destroy(this.gameObject);//刪除物件
                return;
            }
        }
        //找到dropfield但不允許放入或未抓到dropField
        rectTransform.anchoredPosition = StoredPosition;
        OnEndDragHandler?.Invoke(eventData, false);

    }
    public RectTransform GetRect()
    {
        return rectTransform;
    }
    public abstract void MoveItemToFilledField(MovableImageUI movOld , MovableImageUI movNew);
    private void realeseField(DropField field)
    {
        Debug.Log("release : " + field);
        field.UnDrop(this);
        field = null;
    }

}
