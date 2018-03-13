using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class NewStageObserverArchievement : IGameEventObserver
{
    private NewStageSubject mSubject;

    private ArchievementSystem mArchievementSystem;

    public NewStageObserverArchievement(ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject=subject as NewStageSubject;
    }

    public override void Update()
    {
        mArchievementSystem.SetMaxStage(mSubject.stageCount);
    }
}
