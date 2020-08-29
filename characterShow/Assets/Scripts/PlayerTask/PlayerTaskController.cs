using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTaskController : MonoBehaviour
{
    // Start is called before the first frame update
    public TaskSystem taskSystem;

    public PlayerTaskController() 
    {
        taskSystem = new TaskSystem();
    }
}
