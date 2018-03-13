using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum WeaponType
{
    Gun=0,
    Rifle=1,
    Rocket=2,
    Max
}
public abstract class IWeapon
{


    protected WeaponBaseAttr mBaseAttr;
    protected int mAtkPlusValue;
    protected GameObject mGameObject;
    protected ICharacter mOwner;
    protected ParticleSystem mParticleSystem;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;
    protected float mEffectDisplayTime=0;

    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;
        Transform effect = mGameObject.transform.Find("Effect");
        mParticleSystem = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }
    public float atkRange{get { return mBaseAttr.atkRange; } }
    public int atk { get { return mBaseAttr.atk; } }
    public ICharacter owner { set { mOwner = value; } }
    public GameObject gameObject { get { return mGameObject; } }

    public  void Fire(Vector3 targetPosition)
    {
        //播放枪口特效
        PlayMuzzleEffect();

        //播放子弹特效
        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffectDisplayTime();

        //播放声音特效
        PlaySound();

    }
    
        
  

    protected virtual void PlayMuzzleEffect()
    {
        mParticleSystem.Stop();
        mParticleSystem.Play();
        mLight.enabled = true;
    }



    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    protected void DoPlayBulletEffect(float width,Vector3 targetPosition)
    {
        mLine.enabled = true;
        mLine.startWidth = width;mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    protected abstract void SetEffectDisplayTime();

    protected abstract void PlaySound();

    protected void DoPlaySound(string ClipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(ClipName);
        mAudio.clip = clip;
        mAudio.Play();

    }

    protected void DisableEffect()
    {
        mLight.enabled = false;
        mLine.enabled = false;
    }
    

    

}
