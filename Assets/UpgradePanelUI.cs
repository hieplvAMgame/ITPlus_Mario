using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UpgradePanelUI : MonoBehaviour
{
    public Text txtTitle;
    public Text txtBefore;
    public Text txtAfter;
    public Text txtPrice;

    public Button btnBuy;
    public Button btnExit;

    public float duration = .3f;

    private int price;
    private Vector3 _originPos;
    private WeaponScriptable weaponData;
    private int _id;
    private void Awake()
    {
        InfoElement.OnClickUpgrade = SetupUI;
        btnBuy.onClick.AddListener(OnClickBuyBtn);
        btnExit.onClick.AddListener(() => gameObject.SetActive(false));
    }
    public void AnimateActive()
    {
        _originPos = transform.localPosition;
        transform.localPosition = new Vector3(Screen.width, 0, 0);
        transform.DOLocalMoveX(_originPos.x, duration);
    }
    public void AnimateDeActive()
    {
        transform.DOLocalMoveX(Screen.width, duration);
    }
    int _originLvl, _nextLvl;
    public void SetupUI(int id)
    {
        _id = id;
        weaponData = weaponData = WeaponManager.Instance.weaponDatas[PlayerData.Instance.CurrentWeapon];
        txtTitle.text = ((TYPE_INFO_WEAPON)id).ToString();
        switch ((TYPE_INFO_WEAPON)id)
        {
            case TYPE_INFO_WEAPON.DAMAGE:
                price = 100;
                txtPrice.text = price.ToString() + "$";
                _originLvl = WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, id);
                Debug.LogError($"ORIGIN VALUE {_originLvl}");
                _nextLvl = _originLvl+1;
                Debug.LogError($"NEXT VALUE {_nextLvl}");
                txtBefore.text = (weaponData.baseDamage
                    + _originLvl*2).ToString();
                txtAfter.text = (weaponData.baseDamage
                    + _nextLvl*2).ToString();
                break;
        }
    }
    private void OnClickBuyBtn()
    {
        PlayerData.Instance.Gold -= price;
        WeaponManager.Instance.SaveDataWeapon(PlayerData.Instance.CurrentWeapon, _id, _nextLvl);
        InformationUiManager.Instance.SetupUI();
        //AnimateDeActive();
        gameObject.SetActive(false);
    }
}
