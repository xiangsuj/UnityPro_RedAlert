using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ArchievementSystem : IGameSystem
{
    private int mEnemyKilledCount=0;
    private int mSoldierKilledCount=0;
    private int mMaxStage=1;

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled,new EnemyKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverArchievement(this));
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
        Debug.Log("Enemy Killed Count:"+mEnemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
        Debug.Log("Soldier Killed Count:" + mSoldierKilledCount);
    }

    public void SetMaxStage(int stageLv)
    {
        mMaxStage = Mathf.Max(mMaxStage, stageLv);
        Debug.Log("Max stage lv:" + mMaxStage);
    }

    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento=new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStage;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStage = memento.maxStageLv;
    }
}