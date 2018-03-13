using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class CaptiveCamp : ICamp
{

  
   
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;
    private int mEnergyCostTrain;
    public CaptiveCamp(GameObject gameObject, string name, string spriteName, EnemyType enemyType, Vector3 position,
        float trainTime) :
        base(gameObject, name, spriteName, SoldierType.Captive, position, trainTime)
    {
        mEnemyType = enemyType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpgradeEnergyCost();
    }
    public override int lv
    {
        get { return 1; }
    }

    public override WeaponType weaponType {get { return mWeaponType; }}

    public override int energyCostUpgradeCamp {get { return 0; }}

    public override int energyCostUpgradeWeapon { get { return 0; } }

    public override int energyCostTrain { get { return mEnergyCostTrain; } }

    public override void Train()
    {
        CaptiveTrainCammand cmd=new CaptiveTrainCammand(mEnemyType,mWeaponType,mPosition,1);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
        
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpgradeEnergyCost()
    {
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(SoldierType.Captive,1);
    }
}
