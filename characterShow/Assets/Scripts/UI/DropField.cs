using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropField : MonoBehaviour
{
    public List<DropCondition> DropConditions = new List<DropCondition>();
    public event Action<MovableImageUI> OnDropHandler; //統整所有drop的動作
    public bool hasItem = false;

    public bool Accepts(MovableImageUI movable) 
    {
        //若清單中有元素，則依據fuction回傳之變數回傳布林值
        //若無元素，則都回傳true
        return DropConditions.TrueForAll(cond => cond.Check(movable));
    }
    public void Drop(MovableImageUI movable)
    {
        OnDropHandler?.Invoke(movable);
    }
}
