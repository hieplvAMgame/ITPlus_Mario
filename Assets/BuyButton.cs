using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyButton : MonoBehaviour
{
    public int id;
    public TYPE_INFO_WEAPON type;
    public Text txtBefore;
    public Text txtAfter;
    public Text txtPrice;
    public Button btnBuy;

    public static System.Action OnClickUpgradeCharacter;

    private const int price = 200;
    private int beforeValue, afterValue;
    public void SetupUI()
    {
        txtPrice.text = price.ToString() + "$";
        switch (type)
        {
            case TYPE_INFO_WEAPON.DAMAGE:
                beforeValue = PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].damage +
                    PlayerData.Instance.DamageLvl * 2;
                afterValue = PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].damage +
                    (PlayerData.Instance.DamageLvl + 1) * 2;
                txtBefore.text = beforeValue.ToString();
                txtAfter.text = afterValue.ToString();
                btnBuy.onClick.AddListener(() =>
                {
                    if (PlayerData.Instance.Gold < price) return;
                    PlayerData.Instance.Gold -= price;
                    OnClickUpgradeCharacter?.Invoke();
                    PlayerData.Instance.DamageLvl++;
                });
                break;
            case TYPE_INFO_WEAPON.HP:
                beforeValue = PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].hp +
                    PlayerData.Instance.HpLvl * 2;
                afterValue = PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].hp +
                    (PlayerData.Instance.HpLvl + 1) * 2;
                txtBefore.text = beforeValue.ToString();
                txtAfter.text = afterValue.ToString();
                btnBuy.onClick.AddListener(() =>
                {
                    if (PlayerData.Instance.Gold < price) return;
                    PlayerData.Instance.Gold -= price;
                    OnClickUpgradeCharacter?.Invoke();
                    PlayerData.Instance.HpLvl++;
                });
                break;
            case TYPE_INFO_WEAPON.SPEED:
                beforeValue = (int)(PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].speed +
                    PlayerData.Instance.SpeedLvl * 2);
                afterValue = (int)PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].speed +
                    (PlayerData.Instance.SpeedLvl + 1) * 2;
                txtBefore.text = beforeValue.ToString();
                txtAfter.text = afterValue.ToString();
                btnBuy.onClick.AddListener(() =>
                {
                    if (PlayerData.Instance.Gold < price) return;
                    PlayerData.Instance.Gold -= price;
                    OnClickUpgradeCharacter?.Invoke();
                    PlayerData.Instance.SpeedLvl++;
                });
                break;
            case TYPE_INFO_WEAPON.JUMP:
                beforeValue = (int)PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].jumpForce +
                    PlayerData.Instance.JumpLvl * 2;
                afterValue = (int)PlayerData.Instance.characterDatas[PlayerData.Instance.CurrentCharacter].jumpForce +
                    (PlayerData.Instance.JumpLvl + 1) * 2;
                txtBefore.text = beforeValue.ToString();
                txtAfter.text = afterValue.ToString();
                btnBuy.onClick.AddListener(() =>
                {
                    if (PlayerData.Instance.Gold < price) return;
                    PlayerData.Instance.Gold -= price;
                    OnClickUpgradeCharacter?.Invoke();
                    PlayerData.Instance.JumpLvl++;
                });
                break;

        }
    }
}
