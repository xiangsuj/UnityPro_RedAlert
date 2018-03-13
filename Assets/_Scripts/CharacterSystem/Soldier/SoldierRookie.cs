using System;
using System.Collections.Generic;
using System.Text;

public class SoldierRookie : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("RookieDeath");
    }
}
