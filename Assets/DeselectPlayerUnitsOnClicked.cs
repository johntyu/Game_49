using UnityEngine;
using System.Collections;

public class DeselectPlayerUnitsOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Clicked(){
		unitManager.DeselectUnits();
	}
}
