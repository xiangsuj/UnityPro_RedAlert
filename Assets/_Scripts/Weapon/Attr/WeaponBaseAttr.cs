using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class WeaponBaseAttr
{
    protected string mName;
    protected int mAtk;
    protected float mAtkRange;
    protected string mAssetName;

    public WeaponBaseAttr(string name, int atk, float atkRange,string assetName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }

    public string name { get { return mName; } }
    public int atk { get { return mAtk; } }
    public float atkRange { get { return mAtkRange; } }
    public string assetName { get { return mAssetName; } }
}
