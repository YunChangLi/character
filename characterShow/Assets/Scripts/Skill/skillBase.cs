using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class skillBase : MonoBehaviour
{
    public int CD;
    public int skillTime;
    private int curCD = 10;
    [SerializeField]
    private KeyCode shortCut;
    private Coroutine skillWait;

    public virtual void skillInit(KeyCode shortCut) {
        curCD = CD;
        this.shortCut = shortCut;
    }
    public abstract void skilling();
    public abstract void skillFinish();

    public int getCD() {
        return CD;
    }

    public bool mSkill() {  //update
        if (curCD == 10)
        {
            if (Input.GetKey(shortCut)) {
                skillWait = StartCoroutine(skillWaitCoroutine());
            }
            //Debug.Log("CanSkill");
            
            
            return true;
        }
        else
        {
            StopCoroutine(skillWaitCoroutine());
            //Debug.Log("CannotSkill");
            return false;
        }
    
    }
    public IEnumerator skillWaitCoroutine() {
        curCD = 0;
        yield return new WaitForSeconds(CD + skillTime);
        curCD = CD;
    }

    
}
