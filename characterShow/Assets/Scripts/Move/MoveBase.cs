using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void MoveInit(Animator animator/*FlowData*/)
    {
        this.animator = animator;
    }
    public void Moving()
    {

    }
    public void MoveStop()
    {


    }
}
