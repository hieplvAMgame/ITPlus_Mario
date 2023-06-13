using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoElement : MonoBehaviour
{
    public TYPE_INFO_WEAPON type;
    public WeaponScriptable weaponData;
    public Text txtTitle;
    public Text txtValue;
    public Button selfButton;
    public static System.Action<int> OnClickUpgrade;
    public void Setup()
    {
        weaponData = WeaponManager.Instance.weaponDatas[PlayerData.Instance.CurrentWeapon];
        selfButton.onClick.AddListener(() =>
        {
            OnClickUpgrade?.Invoke((int)type);
            Debug.LogError($"{type} is Press");
        });
        txtTitle.text = type.ToString();
        switch (type)
        {
            case TYPE_INFO_WEAPON.DAMAGE:
                txtValue.text = (weaponData.baseDamage
                    + WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, (int)type)).ToString();
                break;
            case TYPE_INFO_WEAPON.HP:
                txtValue.text = (weaponData.baseHp
                    + WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, (int)type)).ToString();
                break;
            case TYPE_INFO_WEAPON.SPEED:
                txtValue.text = (weaponData.baseSpeed
                    + WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, (int)type)).ToString();
                break;
            case TYPE_INFO_WEAPON.JUMP:
                txtValue.text = (weaponData.baseJumpForce
                    + WeaponManager.Instance.GetDataWeapon(
                        PlayerData.Instance.CurrentWeapon, (int)type)).ToString();
                break;
        }
    }
}
public enum TYPE_INFO_WEAPON
{
    DAMAGE,
    HP,
    SPEED,
    JUMP
}
