using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}
