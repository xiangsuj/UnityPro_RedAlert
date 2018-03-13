using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public interface  IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}
