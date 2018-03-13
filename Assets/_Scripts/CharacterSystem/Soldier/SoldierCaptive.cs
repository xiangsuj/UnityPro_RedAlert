using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        
        ICharacterAttr attr=new SoldierAttr(enemy.attr.strategy,1,enemy.attr.baseAttr);
        this.attr = attr;
        this.gameObject = mGameObject.gameObject;
        this.weapon = mEnemy.weapon;

    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
       //do nothing
    }
}
