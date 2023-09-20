using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
	[SerializeField] TMP_Text weaponName;
	private void Awake () {
		Events.UI.OnWeaponSwitched += OnWeaponSwitched;
	}
	private void OnDestroy () {
		Events.UI.OnWeaponSwitched -= OnWeaponSwitched;
	}

	void OnWeaponSwitched(string name) {
		weaponName.SetText (name);
	}
}
