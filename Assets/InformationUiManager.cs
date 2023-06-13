using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUiManager : Singleton<InformationUiManager>
{
    public List<InfoElement> infoElements = new List<InfoElement>();
    public Text txtTitle;
    public Image previewWeapon;

    public Transform contentWeaponUI;
    public WeaponElementUI weaponElementUI;
    private List<WeaponElementUI> listWeaponUI = new List<WeaponElementUI>();

    private void Awake()
    {
        GenerateUIWeapon();
        SetupUI();
    }
    private void SetupUI()
    {
        infoElements.ForEach(x => x.Setup());
        txtTitle.text = WeaponManager.Instance.weaponDatas[PlayerData.Instance.CurrentWeapon]
            .name;
        previewWeapon.sprite = WeaponManager.Instance.weaponDatas[PlayerData.Instance.CurrentWeapon]
            .preview;
    }
    private void GenerateUIWeapon()
    {
        listWeaponUI.Clear();
        for(int i=0;i< WeaponManager.Instance.weaponDatas.Count; i++)
        {
            int _index = i;
            WeaponElementUI cloneUI = Instantiate(weaponElementUI, contentWeaponUI);
            cloneUI.SetupUI(WeaponManager.Instance.weaponDatas[_index], _index);
            cloneUI.gameObject.SetActive(true);
            listWeaponUI.Add(cloneUI);
        }
    }
    public void UpdateBtnUI()
    {
        SetupUI();
        listWeaponUI.ForEach(x => x.UpdateUIBtn());
    }
}
