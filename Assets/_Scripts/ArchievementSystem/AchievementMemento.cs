using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AchievementMemento
{
    public int enemyKilledCount { set; get; }
    public int soldierKilledCount { set; get; }
    public int maxStageLv { set; get; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("enemyKilledCount",enemyKilledCount);
        PlayerPrefs.SetInt("soldierKilledCount", soldierKilledCount);
        PlayerPrefs.SetInt("maxStageLv", maxStageLv);
    }

    public void LoadData()
    {
        enemyKilledCount = PlayerPrefs.GetInt("enemyKilledCount");
        soldierKilledCount = PlayerPrefs.GetInt("soldierKilledCount");
        maxStageLv = PlayerPrefs.GetInt("maxStageLv");
    }
}
