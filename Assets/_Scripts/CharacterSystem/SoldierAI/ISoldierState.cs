using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition=0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mSoldierStateID;
    
    public SoldierStateID stateID { get { return mSoldierStateID; } }
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierStateError: trans不能为空");return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierStateError: id不能为空");return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierStateError: " + trans + "已经存在");return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件时，转换条件[" + trans+"]不存在");return;
        }
        mMap.Remove(trans);
    }

    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            return SoldierStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }

    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter>targets);
    public abstract void Act(List<ICharacter> targets);
}

