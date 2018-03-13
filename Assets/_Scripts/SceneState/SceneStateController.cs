using System;
using System.Collections.Generic;

using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateController
{
    private ISceneState mState;
    private AsyncOperation mAO;//异步加载场景是否完成
    private bool mIsRunStart = false;//是否调用过一次StateStart

    public void SetState(ISceneState state, bool isLoadScene = true)
    {
        if (mState != null)
        {
            mState.StateEnd();
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateAwake();
            mState.StateStart();
            mIsRunStart = true;
        }
      
    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false) { return;}

        if (mIsRunStart==false&&mAO != null && mAO.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;
        }
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}