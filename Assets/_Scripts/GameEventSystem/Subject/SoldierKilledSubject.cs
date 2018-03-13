using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierKilledSubject : IGameEventSubject
{
    private int mKilledCount = 0;

    public int killedCount { get { return mKilledCount; } }

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}