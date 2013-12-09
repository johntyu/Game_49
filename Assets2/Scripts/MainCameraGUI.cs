using UnityEngine;
using System.Collections;

public class MainCameraGUI : MonoBehaviour {
	
	private UnitManager unitManager;
	private CivilianManager civManager;

	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		civManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<CivilianManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(10, 10, 100, 20), unitManager.NumUnits() + "/" + unitManager.numUnitsAllowed);
		GUI.Box(new Rect(10, 35, 100, 20), civManager.NumCivilians() + "/" + civManager.totalCiviliansAllowed);
		if(unitManager.getNumSelectedUnits() == 1){
			GameObject unit = unitManager.GetSelectedUnits()[0];
			if(unit != null){
				if(unit.name.Contains("Friendly_Civilian")){
					UnitHealth unitHealth = unit.GetComponent<UnitHealth>();
					MeleeAttackUnitsInRange unitDamage = unit.GetComponent<MeleeAttackUnitsInRange>();
					GUI.Box(new Rect(Screen.width / 8.0f, 17.0f * Screen.height / 20.0f, Screen.width / 4.0f, Screen.height / 15.0f), "Health: " + unitHealth.curHealth);
					GUI.Box(new Rect(Screen.width / 8.0f, 18.5f * Screen.height / 20.0f, Screen.width / 4.0f, Screen.height / 15.0f), "Damage: " + unitDamage.meleeDamage);
				}
			}
		}
	}
}
