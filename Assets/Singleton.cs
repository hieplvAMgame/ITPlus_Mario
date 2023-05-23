using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance;       // T la PlayerController
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Destroy(Instance);
        }
    }
}
