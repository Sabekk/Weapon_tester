using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] Transform handle;

	List<string> allWeapons;

	Dictionary<string, Weapon> weapons;

	int currentWeaponId = 0;
	Weapon equipedWeapon;

	private void Awake () {
		allWeapons = new List<string> ();
		weapons = new Dictionary<string, Weapon> ();
		Events.Gameplay.Shot += Shot;
		Events.Gameplay.SwitchWeapon += SwitchWeapon;
	}
	private void Start () {
		GetAllWeapons ();
	}
	private void OnDestroy () {
		Events.Gameplay.Shot -= Shot;
		Events.Gameplay.SwitchWeapon -= SwitchWeapon;
	}

	void GetAllWeapons () {
		ObjectPool.Instance.GetAllPoolsOfType ("Weapon", ref allWeapons);
		//foreach (var weaponName in allWeapons) {
		//	Weapon newWeapon = ObjectPool.Instance.GetFromPool (weaponName).GetComponent<Weapon> ();
		//	newWeapon.Initialize ();
		//	weapons.Add (newWeapon);
		//}
	}

	void Shot () {
		if (equipedWeapon == null)
			return;
		if (!equipedWeapon.CanBeUsed) {
			Debug.Log ("Weapon cant be used: " + equipedWeapon.WeaponName);
			return;
		} else {
			equipedWeapon.Use ();
		}
	}
	void SwitchWeapon () {
		if (equipedWeapon) {
			equipedWeapon.OnUnequip ();
			ObjectPool.Instance.ReturnToPool (equipedWeapon);
		}

		currentWeaponId++;
		if (allWeapons.Count <= currentWeaponId)
			currentWeaponId = 0;

		Weapon newWeapon = ObjectPool.Instance.GetFromPool (allWeapons[currentWeaponId]).GetComponent<Weapon> ();
		weapons.TryGetValue (newWeapon.WeaponName, out Weapon ownedWeapon);

		if (!ownedWeapon) {
			weapons.Add (newWeapon.WeaponName, newWeapon);
			newWeapon.Initialize ();
		} else 
			newWeapon.SetStatistics (ownedWeapon);

		equipedWeapon = newWeapon;
		equipedWeapon.transform.SetParent (handle);
		equipedWeapon.OnEquip ();
	}
}
