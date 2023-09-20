using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] Transform handle;

	List<string> allWeapons;

	Weapon[] weapons;
	public Weapon equipedWeapon;

	private void Awake () {
		Events.Gameplay.Shot += Shot;
		Events.Gameplay.SwitchWeapon += SwitchWeapon;
	}
	private void OnDestroy () {
		Events.Gameplay.Shot -= Shot;
		Events.Gameplay.SwitchWeapon -= SwitchWeapon;
	}

	void Shot () {
		if (equipedWeapon == null)
			return;
		EditorUtility.SetDirty (equipedWeapon);
		if (!equipedWeapon.CanBeUsed) {
			Debug.Log ("Weapon cant be used: " + equipedWeapon.WeaponName);
			return;
		} else {
			equipedWeapon.Use ();
		}
	}
	void SwitchWeapon () {
		Weapon weapon = ObjectPool.Instance.GetFromPool ("meleeWeapon_katana").GetComponent<Weapon> ();
	}
}
