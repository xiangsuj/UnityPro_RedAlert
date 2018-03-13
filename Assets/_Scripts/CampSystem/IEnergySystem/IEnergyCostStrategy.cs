using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
//能量消耗策略
public abstract class IEnergyCostStrategy
{
    public abstract int GetCampUpgradeCost( SoldierType st,int lv);
    public abstract int GetWeaponUpgradeCost(WeaponType wt);
    public abstract int GetSoldierTrainCost(SoldierType st,int lv);
}
