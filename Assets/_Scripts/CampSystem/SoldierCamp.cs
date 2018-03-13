using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierCamp : ICamp
{
    private const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string spriteName, SoldierType soldierType, Vector3 position,
        float trainTime,int lv=1, WeaponType weaponType=WeaponType.Gun) :
        base(gameObject, name, spriteName, soldierType, position,trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType; 
        mEnergyCostStrategy=new SoldierEnergyCostStrategy();
        UpgradeEnergyCost();
    }

    public override int lv{ get { return mLv; } }

    public override WeaponType weaponType { get { return mWeaponType; } }

    public override int energyCostUpgradeCamp
    {
        get
        {
            if (mLv == MAX_LV)
                return -1;
            else
            {
                return mEnergyCostCampUpgrade;


            }
        }
    }

    public override int energyCostUpgradeWeapon
    {
        get
        {
            if (mWeaponType + 1 == WeaponType.Max)
            {
                return -1;
            }
            else
            {
                return mEnergyCostWeaponUpgrade;
            }
        }
    }

    public override int energyCostTrain
    {
        get { return mEnergyCostTrain; }
    }

    public override void Train()
    {
        
        SoldierTrainCommand cmd=new SoldierTrainCommand(mSoldierType,mWeaponType,mPosition,mLv);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        mLv++;
        UpgradeEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpgradeEnergyCost();
    }

    protected override void UpgradeEnergyCost()
    {
        mEnergyCostCampUpgrade = mEnergyCostStrategy.GetCampUpgradeCost(mSoldierType, mLv);
        mEnergyCostWeaponUpgrade = mEnergyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);
    }
}
