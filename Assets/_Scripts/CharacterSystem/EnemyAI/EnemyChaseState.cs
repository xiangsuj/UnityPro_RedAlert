using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mEnemyStateID = EnemyStateID.Chase;
    }

    private Vector3 mTargetPosition;
    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].position);
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(targets[0].position, mCharacter.position);
            if (distance <= mCharacter.atkRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
           
        }
    }
}
