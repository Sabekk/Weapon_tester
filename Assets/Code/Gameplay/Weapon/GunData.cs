using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : WeaponData {

	public int magazine;
	public int maxAmmountOfBullets;
	int bulletsLeft;
	public override void Use () {

	}
}
