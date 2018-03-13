using System;
using System.Collections.Generic;
using System.Text;

public class EnemyOgre : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}