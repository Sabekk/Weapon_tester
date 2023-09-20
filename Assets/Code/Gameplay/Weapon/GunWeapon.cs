using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon {
	[SerializeField] protected GunData gunData;
	public override string WeaponName => gunData.weaponName;
	public override bool CanBeUsed => bulletsLeft > 0;
	float Magazine => gunData.magazine;
	float bulletsLeft;

	public override void Initialize () {
		bulletsLeft = gunData.magazine;
	}

	public override void Use () {
		bulletsLeft--;
		Debug.Log (WeaponName + " used, Bullets in magazine left: " + bulletsLeft + "/" + Magazine);
	}

	public override void SetStatistics (Weapon weapon) {
		if (weapon is GunWeapon gunWeapon) {
			bulletsLeft = gunWeapon.bulletsLeft;
		}
	}
}
