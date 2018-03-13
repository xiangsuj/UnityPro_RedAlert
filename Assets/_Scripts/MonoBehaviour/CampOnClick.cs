using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class CampOnClick : MonoBehaviour
{
    private ICamp mCamp;
    public ICamp camp { set { mCamp = value; } }

    void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfo(mCamp);
    }
}
