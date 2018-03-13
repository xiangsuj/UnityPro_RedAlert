using System;
using System.Collections.Generic;

using System.Text;

public interface IAttrStrategy
{
   int GetExtraHPValue(int lv);
   int GetDmgDescValue(int lv);
    int GetCritDmg(float critRate);
}
