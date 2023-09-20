using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, ObjectPool.IPoolable {
	public abstract string WeaponName { get; }
	public abstract bool CanBeUsed { get; }

	public ObjectPool.PoolObject Poolable { get; set; }

	public abstract void Initialize ();
	public abstract void SetStatistics (Weapon weapon);
	public abstract void Use ();
	public virtual void OnEquip () {
		transform.localPosition = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}

	public virtual void OnUnequip () {

	}

	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
	}
}
