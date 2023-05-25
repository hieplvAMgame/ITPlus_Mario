using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ObjectPooling pooling;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pooling.GetObjectFromPool("Obj1");
            Debug.LogError("Q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            pooling.GetObjectFromPool("Obj1 (1)");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            pooling.GetObjectFromPool("Obj1 (2)");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            pooling.GetObjectFromPool("Obj1 (3)");
        }
    }
}
