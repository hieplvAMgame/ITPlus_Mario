using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IGameSubcriber
{
    private bool canMove = false;
    public GAME_STATE state = GAME_STATE.Game_Prepare;
    public void GameComplete()
    {
        canMove = false;
        state = GAME_STATE.Game_Complete;
    }

    public void GameOver()
    {
        canMove = false;
        state = GAME_STATE.Game_Complete;
    }

    public void GamePause()
    {
        canMove = false;
        state = GAME_STATE.Game_Pause;
    }

    public void GamePrepare()
    {
        canMove = false;
        //SetupPlayer();
        state = GAME_STATE.Game_Prepare;
    }

    public void GameResume()
    {
        canMove = true;
        state = GAME_STATE.Game_Resume;

    }

    public void GameStart()
    {
        canMove = true;
        state = GAME_STATE.Game_Start;
    }
    private void Start()
    {
        GameManager.Instance.AddSubcriber(this);
    }
}
