using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
	public abstract string WeaponName { get; }
	public abstract bool CanBeUsed { get; }
	public abstract void Initialize ();
	public abstract void Use ();
	public virtual void OnEquip () {

	}

	public virtual void OnUnequip () {

	}
}
