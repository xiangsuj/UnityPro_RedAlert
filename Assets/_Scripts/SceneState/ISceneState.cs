using System;
using System.Collections.Generic;

using System.Text;

public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public ISceneState(string sceneName, SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }

    public string SceneName
    {
        get { return mSceneName; }
    }

    public virtual void StateAwake()
    {
        
    }

    public virtual void StateStart()
    {
        
    }

    public virtual void StateEnd()
    {
        
    }

    public virtual void StateUpdate()
    {
        
    }
}