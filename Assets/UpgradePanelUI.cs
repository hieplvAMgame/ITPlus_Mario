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
        btnExit.onClick.AddListener(() => AnimateDeActive());
    }
    public void AnimateActive()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, duration);
    }
    public void AnimateDeActive()
    {
        transform.DOScale(Vector3.zero, duration);
        gameObject.SetActive(false);
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
                    + _originLvl* weaponData.mulDame).ToString();
                txtAfter.text = (weaponData.baseDamage
                    + _nextLvl* weaponData.mulDame).ToString();
                break;
            case TYPE_INFO_WEAPON.HP:
                price = 100;
                txtPrice.text = price.ToString() + "$";
                _originLvl = WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, id);
                Debug.LogError($"ORIGIN VALUE {_originLvl}");
                _nextLvl = _originLvl + 1;
                Debug.LogError($"NEXT VALUE {_nextLvl}");
                txtBefore.text = (weaponData.baseHp
                    + _originLvl * weaponData.mulHP).ToString();
                txtAfter.text = (weaponData.baseHp
                    + _nextLvl * weaponData.mulHP).ToString();
                break;
            case TYPE_INFO_WEAPON.JUMP:
                price = 100;
                txtPrice.text = price.ToString() + "$";
                _originLvl = WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, id);
                Debug.LogError($"ORIGIN VALUE {_originLvl}");
                _nextLvl = _originLvl + 1;
                Debug.LogError($"NEXT VALUE {_nextLvl}");
                txtBefore.text = (weaponData.baseJumpForce
                    + _originLvl * weaponData.mulJump).ToString();
                txtAfter.text = (weaponData.baseJumpForce
                    + _nextLvl * weaponData.mulJump).ToString();
                break;
            case TYPE_INFO_WEAPON.SPEED:
                price = 100;
                txtPrice.text = price.ToString() + "$";
                _originLvl = WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, id);
                Debug.LogError($"ORIGIN VALUE {_originLvl}");
                _nextLvl = _originLvl + 1;
                Debug.LogError($"NEXT VALUE {_nextLvl}");
                txtBefore.text = (weaponData.baseSpeed
                    + _originLvl * weaponData.mulSpeed).ToString();
                txtAfter.text = (weaponData.baseSpeed
                    + _nextLvl * weaponData.mulSpeed).ToString();
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
