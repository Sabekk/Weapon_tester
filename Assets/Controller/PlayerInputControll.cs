using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControll : MonoBehaviour, PlayerControll.IGameplayActions {
	static PlayerControll _controll;
	public static PlayerControll Input {
		get {
			if (_controll == null)
				_controll = new PlayerControll ();
			return _controll;
		}
	}
	private void Awake () {
		Input.Gameplay.SetCallbacks (this);
	}
	void OnEnable () {
		Input.Enable ();
	}
	void OnDisable () {
		Input.Disable ();
	}

	public void OnMouseLeft (InputAction.CallbackContext context) {
		if (context.performed)
			Events.Gameplay.Shot.Invoke ();
	}

	public void OnMouseRoght (InputAction.CallbackContext context) {
		if (context.performed)
			Events.Gameplay.SwitchWeapon.Invoke ();
	}
}
