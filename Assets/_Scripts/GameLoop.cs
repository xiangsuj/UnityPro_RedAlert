using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{

    private SceneStateController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
		controller=new SceneStateController();
        controller.SetState(new StartState(controller),false);
	}
	
	// Update is called once per frame
	void Update () {
        if(controller!=null)
		controller.StateUpdate();
	}
}
