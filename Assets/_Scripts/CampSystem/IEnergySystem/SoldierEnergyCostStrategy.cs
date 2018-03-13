using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpgradeCost(SoldierType st, int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 50;
                break;
            case SoldierType.Sergeant:
                energy = 60;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                Debug.LogError("无法获取"+st+"类型兵营升级所消耗的能量值");
                break;
                
        }
        energy += (lv - 1) * 2;
        if (energy > 100) energy = 100;
        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType st, int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                Debug.LogError("无法获取"+st+"类型士兵生产所需要的能量");
                break;
        }
        energy += (lv - 1) * 3;
        if (energy > 100) energy = 100;
        return energy;
    }

    public override int GetWeaponUpgradeCost(WeaponType wt)
    {
        int energy = 0;
        switch (wt)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 50;
                break;
            default:
                Debug.Log("无法获取"+wt+"类型武器升级所需要的能量");
                break;
        }
        return energy;
    }
}
