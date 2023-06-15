using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPanel : MonoBehaviour
{
    public List<BuyButton> buyButtons = new List<BuyButton>();
    public List<Text> txtValues = new List<Text>();

    public Button closeBtn;
    private void Awake()
    {
        closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
        BuyButton.OnClickUpgradeCharacter = SetUpUI;
        for (int i = 0; i < buyButtons.Count; i++)
        {
            buyButtons[i].id = i;
            buyButtons[i].SetupUI();
        }
        SetUpUI();
    }
    private void SetUpUI()
    {
        txtValues[0].text  = (PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].damage +
                    PlayerData.Instance.DamageLvl * 2).ToString();
        txtValues[1].text = (PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].hp +
            PlayerData.Instance.HpLvl * 2).ToString();
        txtValues[2].text = (PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].speed +
            PlayerData.Instance.SpeedLvl * 2).ToString();
        txtValues[3].text = (PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].jumpForce +
            PlayerData.Instance.JumpLvl * 2).ToString();
    }
}
