using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IGameSubcriber
{
    public delegate void EventCall(IGameSubcriber sub);

    private List<IGameSubcriber> listSubcriber = new List<IGameSubcriber>();

    public void AddSubcriber(IGameSubcriber sub)
    {
        listSubcriber.Add(sub);
    }
    public void RemoveSubcriber(IGameSubcriber sub)
    {
        listSubcriber.Remove(sub);
    }
    public void CallGameSub(EventCall _event)
    {
        listSubcriber.ForEach(x => _event(x));
    }
    public void GameComplete()
    {
        CallGameSub((sub) => { sub.GameComplete(); });
    }

    public void GameOver()
    {
        CallGameSub((sub) => { sub.GameOver(); });

    }

    public void GamePause()
    {
        CallGameSub((sub) => { sub.GamePause(); });

    }

    public void GamePrepare()
    {
        CallGameSub((sub) => { sub.GamePrepare(); });

    }

    public void GameResume()
    {
        CallGameSub((sub) => { sub.GameResume(); });

    }

    public void GameStart()
    {
        CallGameSub((sub) => { sub.GameStart(); });

    }
}
