using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class skillBase : MonoBehaviour
{
    public int CD;
    public KeyCode shortCut;
    public abstract IEnumerator skillInit();
    public abstract IEnumerator skilling();
    public abstract IEnumerator skillFinish();
    

    
}
