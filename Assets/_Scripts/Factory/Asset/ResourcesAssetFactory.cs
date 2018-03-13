using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesAssetFactory : IAssetFactory
{
    private const string SoliderPath = "Characters/Soldier/";
    private const string EnemyPath = "Characters/Enemy/";
    private const string WeaponPath = "Weapons/";
    private const string EffectPath = "Effects/";
    private const string SpritePath = "Sprites/";
    private const string AudioPath = "Audios/";

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoliderPath + name);

    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载资源，路径:"+path);
            return null;
        }
        return GameObject.Instantiate(o) as GameObject;
    }

    private UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载资源，路径:" + path);
            return null;
        }
        return o;
    }
}
