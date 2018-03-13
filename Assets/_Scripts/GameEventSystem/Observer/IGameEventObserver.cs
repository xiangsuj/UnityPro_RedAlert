using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class IGameEventObserver
{
    public abstract void Update();
    public abstract void SetSubject(IGameEventSubject subject);
}