using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : IBaseUI
{

    private Text mCurrentStageLvLabel;
    private Button mContinueBtn;
    private Button mBackMenuBtn;
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");
        mCurrentStageLvLabel = UITool.FindChild<Text>(mRootUI, "CurrentStageLvLabel");
        mContinueBtn = UITool.FindChild<Button>(mRootUI, "ContinueBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackMenuBtn"); 

        Hide();
    }
}