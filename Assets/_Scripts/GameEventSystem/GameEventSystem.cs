using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum GameEventType{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage
}
public class GameEventSystem : IGameSystem
{
   private Dictionary<GameEventType,IGameEventSubject> mGameEvents=new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }

    private void InitGameEvents()
    {
        mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
        mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
        mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.RegisterObserver(observer);
        observer.SetSubject(sub);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if(sub==null)return;
        sub.RemoveObserver(observer);
        observer.SetSubject(null);
    }

    public void NotifySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.Notify();
    }

    private IGameEventSubject GetGameEventSub(GameEventType eventType)
    {
        if (mGameEvents.ContainsKey(eventType) == false)
        {
            switch (eventType)
            {
                case GameEventType.EnemyKilled:
                    mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("事件类型：" + eventType + "没有对应的主题类"); return null;
            }
           
        }
       return  mGameEvents[eventType];
    }

    
}