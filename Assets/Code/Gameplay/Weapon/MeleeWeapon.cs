using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {
	[SerializeField] protected MeleeWeaponData meleeData;
	float durabilityLeft;
	public override string WeaponName => meleeData.weaponName;
	public override bool CanBeUsed => durabilityLeft <= 0;
	float MaxDurability => meleeData.durability;

	public override void Initialize () {
		durabilityLeft = meleeData.durability;
	}

	public override void Use () {
		durabilityLeft--;
		Debug.Log (WeaponName + " used, Durability left: " + durabilityLeft + "/" + MaxDurability);
	}
}
