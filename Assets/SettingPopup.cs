using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SettingPopup : MonoBehaviour
{
    public Button btnClose; 
    public Transform content = default;
    private float originPosY = -95f;


    private void Awake()
    {
        content.position = new Vector3(Screen.width/2, -Screen.height, 0);
        AnimateAwake();
        btnClose.onClick.AddListener(() => AnimateClose());
    }





    private void AnimateAwake()
    {
        content.DOLocalMoveY(originPosY, .5f);
    }
    private void AnimateClose()
    {
        content.DOLocalMoveY(-Screen.height, .5f)
            .OnComplete(() => Destroy(gameObject));
    }
}
