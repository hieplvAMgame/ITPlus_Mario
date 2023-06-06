using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Singleton<GamePanel>
{
    public Button btnPause = default;
    public PausePopup pausePopup = default;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickBtnPause);
    }

    private void OnClickBtnPause()
    {
        pausePopup.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
