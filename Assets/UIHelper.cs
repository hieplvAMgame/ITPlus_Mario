using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : Singleton<UIHelper>
{
    public void ShowPopup(string name, System.Action callback = null)
    {
        Transform trans = GameObject.Find("Popups").transform;
        GameObject popup = Instantiate(Resources.Load(name) as GameObject, trans);
        callback?.Invoke();
    }
}
