using System;
using System.Collections.Generic;

using System.Text;
public class BattleState:ISceneState
{
    
    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {
        
    }

    public override void StateAwake()
    {
        GameFacade.Instance.Init();
    }

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Instance.Update();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
}