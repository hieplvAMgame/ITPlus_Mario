using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvas : Singleton<HomeCanvas>
{
    public Button btnSetting = default;
    public Button btnPlay = default;
    public Button btnShop = default;

    public Text txtCoin = default;
    public Text txtGem = default;

    private void Awake()
    {
        btnPlay.onClick.AddListener(() => LoadingSceneManager.Instance.LoadScene("Game"));
    }
}
