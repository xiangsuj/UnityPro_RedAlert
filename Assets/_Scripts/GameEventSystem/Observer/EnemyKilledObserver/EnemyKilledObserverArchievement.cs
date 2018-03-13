using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class EnemyKilledObserverArchievement : IGameEventObserver
{
    //private EnemyKilledSubject mSubject;

    private ArchievementSystem mArchievementSystem;

    public EnemyKilledObserverArchievement(ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        //mSubject = subject as EnemyKilledSubject;
    }

    public override void Update()
    {
        mArchievementSystem.AddEnemyKilledCount();
    }
}

