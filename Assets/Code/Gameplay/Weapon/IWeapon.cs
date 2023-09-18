using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    abstract void OnUse ();
    abstract void OnEquip ();
    abstract void OnUnequip ();

}
