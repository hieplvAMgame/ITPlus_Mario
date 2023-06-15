using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Singleton<GamePanel>
{
    public Button btnPause = default;
    public PausePopup pausePopup = default;

    public Button shopBtn;
    public GameObject shopPanel;
    protected override void Awake()
    {
        btnPause.onClick.AddListener(OnClickBtnPause);
        shopBtn.onClick.AddListener(() => shopPanel.SetActive(true));
    }

    private void OnClickBtnPause()
    {
        pausePopup.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
