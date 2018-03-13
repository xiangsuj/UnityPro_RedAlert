using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}
public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mEnemyStateID;

    public EnemyStateID stateID { get { return mEnemyStateID; } }
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyStateError: trans不能为空"); return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyStateError: id不能为空"); return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyStateError: " + trans + "已经存在"); return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件时，转换条件[" + trans + "]不存在"); return;
        }
        mMap.Remove(trans);
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            return EnemyStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }

    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
