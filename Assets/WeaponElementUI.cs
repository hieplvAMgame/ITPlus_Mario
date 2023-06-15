using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponElementUI : MonoBehaviour
{
    public int id;
    public Text txtTitle;
    public Text txtDescrip;
    public Text txtPrice;

    public Image imgPreview;
    public Button btnBuy;
    public Button btnEquip;
    public GameObject btnEquipped;
    public GameObject lockObj;

    private WeaponScriptable data;
    public void SetupUI(WeaponScriptable _data, int _id)
    {
        id = _id;
        data = _data;
        txtTitle.text = data.name;
        txtDescrip.text = data.description;
        imgPreview.sprite = data.preview;
        UpdateUIBtn();
        btnBuy.onClick.AddListener(() =>
        {
            if (PlayerData.Instance.Gold < data.price) return;
            WeaponManager.Instance.SetBuyWeapon(id);
            PlayerData.Instance.Gold -= data.price;
            UpdateUIBtn();
        });
        btnEquip.onClick.AddListener(() =>
        {
            PlayerData.Instance.CurrentWeapon = id;
            InformationUiManager.Instance.UpdateBtnUI();
        });
    }
    public void UpdateUIBtn()
    {
        if (id==PlayerData.Instance.CurrentWeapon)
        {
            btnBuy.gameObject.SetActive(false);
            btnEquip.gameObject.SetActive(false);
            btnEquipped.gameObject.SetActive(true);
            lockObj.SetActive(false);
        }
        else
        {
            btnBuy.gameObject.SetActive(!WeaponManager.Instance.IsBuyWeapon(id));
            btnEquip.gameObject.SetActive(WeaponManager.Instance.IsBuyWeapon(id));
            lockObj.SetActive(!WeaponManager.Instance.IsBuyWeapon(id));
            btnEquipped.gameObject.SetActive(false);
            txtPrice.text = data.price + "$";
        }
    }
}
