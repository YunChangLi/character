using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    /// private用來持有唯一的執行實例
    /// </summary>
    private static T sInstance  = default(T);
  
    public static T instance 
    {
        get 
        {
            if (sInstance == null)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                DontDestroyOnLoad(go);
                sInstance = go.AddComponent(typeof(T)) as T;
            }
            return sInstance;
           
        }
    }

   

}
