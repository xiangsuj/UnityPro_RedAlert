using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ICharacterAttr
{
    protected int mLv;
    protected int mCurrentHP;
    protected int mDmgDescValue;
    protected CharacterBaseAttr mBaseAttr;

    public ICharacterAttr(IAttrStrategy strategy,int lv,CharacterBaseAttr baseAttr)
    {
        mLv = lv;
        mBaseAttr = baseAttr;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = baseAttr.maxHP + mStrategy.GetExtraHPValue(mLv);
    }
    protected IAttrStrategy mStrategy;
    public int critValue { get { return mStrategy.GetCritDmg(mBaseAttr.critRate); } }
    public int currentHP { get { return mCurrentHP; } }
    public IAttrStrategy strategy { get { return mStrategy; } }
    public CharacterBaseAttr baseAttr { get { return mBaseAttr; } }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurrentHP -= damage;
    }
}