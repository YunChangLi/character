using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemField : DropField
{
    // Start is called before the first frame update
    void Awake()
    {
        this.OnDropHandler += ItemDrop;
    }

    private void ItemDrop(MovableImageUI obj) 
    {
    }
}
