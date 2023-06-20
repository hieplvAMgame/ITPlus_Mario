using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : Singleton<GameUIManager>, IGameSubcriber
{
    public List<Button> btn;
    public GameObject winPanel;
    public GameObject losePanel; //GameLosePanel losePanle;
    #region Game Subcriber
    public void GameComplete()
    {
        Debug.LogError("Show Game Win");
        winPanel.SetActive(true);
    }

    public void GameOver()
    {
        Debug.LogError("Show Game OVER");
        losePanel.SetActive(true);
        //losePanel.SetScore();
    }

    public void GamePause()
    {
        Debug.LogError("Show Game PAUSE");

    }

    public void GamePrepare()
    {
        Debug.LogError("Show Game PREPARE");

    }

    public void GameResume()
    {
        Debug.LogError("Show Game RESUME");

    }

    public void GameStart()
    {
        Debug.LogError("Show Game START");

    }

    #endregion
    private void Start()
    {
        GameManager.Instance.AddSubcriber(this);
        for (int i = 0; i < btn.Count; i++)
        {
            int index = i;
            switch (index)
            {
                case 0:
                    btn[index].onClick.AddListener(()=> 
                    GameManager.Instance.GamePrepare());
                    break;
                case 1:
                    btn[index].onClick.AddListener(() =>
                    GameManager.Instance.GameStart());
                    break;
                case 2:
                    btn[index].onClick.AddListener(() =>
                    GameManager.Instance.GamePause());
                    break;
                case 3:
                    btn[index].onClick.AddListener(() =>
                    GameManager.Instance.GameResume());
                    break;
                case 4:
                    btn[index].onClick.AddListener(() =>
                    GameManager.Instance.GameOver());
                    break;
                case 5:
                    btn[index].onClick.AddListener(() =>
                    GameManager.Instance.GameComplete());
                    break;
            }
        }
    }
}
