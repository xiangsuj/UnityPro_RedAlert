using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IBaseUI
{

    public GameFacade mFacade;
    public GameObject mRootUI;

    public virtual void Init()
    {
        mFacade=GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}