using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DestoryForTime : MonoBehaviour
{
    private float time = 1f;
    void Start()
    {
        Invoke("Destory",time);
    }

    void Destory()
    {
        GameObject.DestroyImmediate(this.gameObject);
    }
}