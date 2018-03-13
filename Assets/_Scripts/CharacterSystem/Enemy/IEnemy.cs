using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class IEnemy:ICharacter
{
    protected EnemyFSMSystem mFsmSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public override  void UpdateFSMAI(List<ICharacter> targets)
    {
        if(mIsKilled)return;
        mFsmSystem.currentState.Reason(targets);
        mFsmSystem.currentState.Act(targets);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }

    private void MakeFSM()
    {
        mFsmSystem=new EnemyFSMSystem();
        
        IEnemyState chaseState=new EnemyChaseState(mFsmSystem,this);
        chaseState.AddTransition(EnemyTransition.CanAttack,EnemyStateID.Attack);

        IEnemyState attackState=new EnemyAttackState(mFsmSystem,this);
        attackState.AddTransition(EnemyTransition.LostSoldier,EnemyStateID.Chase);

        mFsmSystem.AddState(chaseState,attackState);
    }

    public override void UnderAttack(int damage)
    {
        if(mIsKilled)return;
        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.currentHP <= 0)
        {
            Killed();
        }
    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }
}