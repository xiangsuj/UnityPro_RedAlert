using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        if (UnityEngine.Random.Range(0, 1f) > 0.5)
        {
            return (int)(10 * UnityEngine.Random.Range(0.5f, 1f));
        }
        else
        {
            return 0;
        }
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 1;
    }

    public int GetExtraValue(int lv)
    {
        return 0;
    }
}
 
