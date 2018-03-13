using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class UITool
{
    public static GameObject FindCanvas(string name)
    {
        return GameObject.Find(name);
    }

    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTool.FindChild(parent, childName);
        if (uiGO == null)
        {
            Debug.LogError("在游戏物体"+parent+"查找不到child："+childName);
            return default(T);
        }
        return uiGO.GetComponent<T>(); 
    }
}
