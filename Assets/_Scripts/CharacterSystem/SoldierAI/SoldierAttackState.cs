using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SoldierAttackState : ISoldierState
{

    private float mAttackTime = 1f;
    private float mAttackTimer = 1f;
    public SoldierAttackState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c)
    {
        mSoldierStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }
    public override void Act(List<ICharacter> targets)
    {
        if(targets==null||targets.Count==0)return;
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);return;
        }
        float distance = Vector3.Distance(targets[0].position, mCharacter.position);
        if (distance > mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}
