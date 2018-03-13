using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierKilledObserverArchievement : IGameEventObserver
{
    private ArchievementSystem mArchievementSystem;

    public SoldierKilledObserverArchievement(ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        return;
        
    }

    public override void Update()
    {
        mArchievementSystem.AddSoldierKilledCount();
    }
}
