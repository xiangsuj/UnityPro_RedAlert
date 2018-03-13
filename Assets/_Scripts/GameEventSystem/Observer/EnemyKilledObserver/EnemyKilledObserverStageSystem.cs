using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;

    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject=subject as EnemyKilledSubject;;
    }

    public override void Update()
    {
        mStageSystem.countOfEnemyKilled = mSubject.killedCount;
    }
}