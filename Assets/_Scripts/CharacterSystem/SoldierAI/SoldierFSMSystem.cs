using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierFSMSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;
    public ISoldierState currentState { get { return mCurrentState; } }

    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }
    public void AddState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态ID[" + s.stateID + "]已经存在");return;
            }
        }
        mStates.Add(state);
    }

    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID);return;
        }

        foreach(ISoldierState s in mStates)
        {
            if (s.stateID == stateID)
            {
                mStates.Remove(s);return;
            }
        }
        Debug.LogError("要删除的stateID不存在集合中:" + stateID);
    }

    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空:" + trans);return;
        }
        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件[" + trans + "]下，没有对应的转换状态");return;

        }
        foreach(ISoldierState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
            }
        }

    }
}
