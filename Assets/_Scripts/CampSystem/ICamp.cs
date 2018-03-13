using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mSpriteName;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition;//集合点
    protected float mTrainTime;
    protected List<ITrainCommand> mCommands;
    protected IEnergyCostStrategy mEnergyCostStrategy;
    protected int mEnergyCostCampUpgrade;
    protected int mEnergyCostWeaponUpgrade;
    protected int mEnergyCostTrain;

    private float mTrainTimer = 0;
    

    public ICamp(GameObject gameObject, string name, string spriteName, SoldierType soldierType, Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mSpriteName = spriteName;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;
        mCommands=new List<ITrainCommand>();
    }

    public virtual void Update()
    {
        UpdateCommand();
    }

    private void UpdateCommand()
    {
        
        if(mCommands.Count<=0)return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }

    }

    public string name { get { return mName; } }
    public string spriteName { get { return mSpriteName; } }
    public abstract int lv { get; }
    public abstract WeaponType weaponType { get; }

    public abstract void Train();
    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();

    public abstract int energyCostUpgradeCamp { get; }
    public abstract int energyCostUpgradeWeapon { get; }
    public abstract int energyCostTrain{ get; }

    public void CancelTrainCommand()
    {
        if (mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count-1);
            if (mCommands.Count == 0)
            {
                mTrainTimer=mTrainTime;
            }
        }
    }

    public int trainCount { get { return mCommands.Count; } }
   

    public float trainRemainTime { get { return mTrainTimer; } }

    protected abstract void UpgradeEnergyCost();
}
