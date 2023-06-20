using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSubcriber
{
    void GamePrepare();
    void GameStart();
    void GamePause();
    void GameResume();
    void GameOver();
    void GameComplete();
}
