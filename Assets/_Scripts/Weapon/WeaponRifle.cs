using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {

    }
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}