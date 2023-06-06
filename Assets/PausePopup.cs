using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PausePopup : MonoBehaviour
{
    [Header("PAUSE CONTENT")]
    public Button resumeBtn = default;
    public Button exitBtn = default;
    public GameObject pauseContent = default;

    [Header("Are You Sure")]
    public Button yesBtn = default;
    public Button noBtn = default;
    public GameObject confirmObj = default;

    private void Awake()
    {
        AddListenerBtn();
    }
    private void AddListenerBtn()
    {
        exitBtn.onClick.AddListener(OnClickedExitBtn);
        resumeBtn.onClick.AddListener(OnClickedResumeBtn);
        yesBtn.onClick.AddListener(OnClickedYesBtn);
        noBtn.onClick.AddListener(OnClickedNoBtn);
    }
    private void OnClickedExitBtn()
    {
        pauseContent.SetActive(false);
        confirmObj.SetActive(true);
    }
    private void OnClickedResumeBtn()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnClickedYesBtn()
    {
        LoadingSceneManager.Instance.LoadScene("Home");
        Time.timeScale = 1;
    }
    private void OnClickedNoBtn()
    {
        pauseContent.SetActive(true);
        confirmObj.SetActive(false);
    }
}
