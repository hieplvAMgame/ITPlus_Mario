using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    protected override void Awake()
    {
        base.Awake();
        SetBuyWeapon(0);
    }
    public List<WeaponScriptable> weaponDatas = new List<WeaponScriptable>();
    public void SaveDataWeapon(int typeWeapon, int typeInfo, int valueSave)
    {
        PlayerPrefs.SetInt(string.Format("DataWeapon" + typeWeapon.ToString() +
            typeInfo.ToString()), valueSave);
    }
    
    public int GetDataWeapon(int typeWeapon, int typeInfo)
    {
        return PlayerPrefs.GetInt(string.Format("DataWeapon" + typeWeapon.ToString() +
            typeInfo.ToString()), 0);
    }
    public void SetBuyWeapon(int typeWeapon)
    {
        PlayerPrefs.SetInt("IsBuyWeapon" + typeWeapon.ToString(), 1);
    }
    public bool IsBuyWeapon(int typeWeapon)
    {
        return PlayerPrefs.GetInt("IsBuyWeapon" + typeWeapon.ToString(), 0) == 1;
    }
}
