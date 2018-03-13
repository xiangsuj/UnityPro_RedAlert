using System;
using System.Collections.Generic;
using System.Text;

public class EnemyElf : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}