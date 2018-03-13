using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class IStageHandler
{
    protected int mLv;
    protected StageSystem mStageSystem;
    protected IStageHandler mNextHandler;
    protected int mCountToFinished;

    public IStageHandler(StageSystem stageSystem,int lv,int countToFinished)
    {
        mStageSystem = stageSystem; 
        mLv = lv;
        mCountToFinished = countToFinished;
    }
    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public void Handle(int lv)
    {
        if (lv == mLv)
        {
            UpdateStage();
            CheckIsFinished();//检查关卡是否结束
        }
        else
        {
            mNextHandler.Handle(lv);
        }
    }

    protected virtual void UpdateStage() { }

    private void CheckIsFinished()
    {
        if (mStageSystem.countOfEnemyKilled >= mCountToFinished)

        {
            mStageSystem.EnterNextStage();
        }
    }
}
