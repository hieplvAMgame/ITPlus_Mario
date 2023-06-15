using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameManager : Singleton<OnGameManager> 
{
    public System.Action<GAME_STATE> OnChangeState;
    public void GamePrepare()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Prepare);
    }
    public void GameStart()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Start);

    }
    public void GamePause()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Pause);
        Time.timeScale = 0;
    }
    public void GameResume()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Resume);
        Time.timeScale = 1;
    }
    public void GameCompelete()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Complete);

    }
    public void GameOver()
    {
        OnChangeState?.Invoke(GAME_STATE.Game_Over);

    }
}
public enum GAME_STATE
{
    Game_Prepare,
    Game_Start,
    Game_Pause,
    Game_Resume,
    Game_Complete,
    Game_Over
}
