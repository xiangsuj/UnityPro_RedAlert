using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierTrainCommand : ITrainCommand
{
    private SoldierType mSoldierType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public SoldierTrainCommand(SoldierType st, WeaponType wt, Vector3 pos, int lv)
    {
        mSoldierType = st;
        mWeaponType = wt;
        mPosition = pos;
        mLv = lv;
    }
    public override void Execute()
    {
       
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
               
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mPosition, mLv);
                break;
            default:
                Debug.LogError("无法根据角色类型"+mSoldierType+"创建角色");
                break;
        }
        
    }
}
