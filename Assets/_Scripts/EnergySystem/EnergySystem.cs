using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const int MAX_Energy = 100;
    private float mCurrentEnergy = MAX_Energy;
    private float mRecoverSpeed = 3;

   

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();
        GameFacade.Instance.UpdateEnergySlider((int)mCurrentEnergy, MAX_Energy);//mFacade找不到。脚本执行顺序无法调整
        if (mCurrentEnergy>MAX_Energy)return;
        mCurrentEnergy += mRecoverSpeed * Time.deltaTime;
        mCurrentEnergy = Mathf.Min(mCurrentEnergy, MAX_Energy);
       

    }

    public bool TakeEnergy(int value)
    {
        if (mCurrentEnergy >= value)
        {
            mCurrentEnergy -= value;
            return true;
        }
        return false;
    }

    public void RecycleEnergy(int value)
    {
        mCurrentEnergy += value;
        mCurrentEnergy = Mathf.Min(mCurrentEnergy, MAX_Energy);
    }
}