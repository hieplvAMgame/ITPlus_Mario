using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvas : Singleton<HomeCanvas>
{
    public Button btnSetting = default;
    public Button btnPlay = default;
    public Button btnShop = default;
    public Button btnUpgrade = default;


    public Text txtCoin = default;
    public Text txtGem = default;

    protected override void Awake()
    {
        base.Awake();
        btnPlay.onClick.AddListener(() => LoadingSceneManager.Instance.LoadScene("Game"));
        btnSetting.onClick.AddListener(() => UIHelper.Instance.ShowPopup("SettingPopups"));
        btnUpgrade.onClick.AddListener(() => LoadingSceneManager.Instance.LoadScene("Upgrade"));
        SetupUI();
    }
    private void SetupUI()
    {
        txtCoin.text = PlayerData.Instance.Gold.ToString();
        txtGem.text = PlayerData.Instance.Gem.ToString();
    }
}
