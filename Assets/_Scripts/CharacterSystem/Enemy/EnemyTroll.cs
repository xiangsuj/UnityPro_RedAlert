using System;
using System.Collections.Generic;
using System.Text;

public class EnemyTroll:IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}