using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singlton<T> : MonoBehaviour where T : Component
{
    static T instance;

    public static T Instance
    {
        get
        {
            if(!Instance)
                instance = FindObjectOfType<T>();

            if(!Instance)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }

            return Instance;
        }
    }

    protected virtual void Awake()
    {
        if(!instance) 
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
