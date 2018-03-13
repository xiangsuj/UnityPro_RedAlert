using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class IGameEventSubject
{
    private List<IGameEventObserver> mGameEventObservers=new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver observer)
    {
        mGameEventObservers.Add(observer);
    }

    public void RemoveObserver(IGameEventObserver observer)
    {
        mGameEventObservers.Remove(observer);
    }

    public virtual void Notify()
    {
        foreach (IGameEventObserver ob in mGameEventObservers)
        {
            ob.Update();
        }
    }
}
