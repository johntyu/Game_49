using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandeerVehicle : MonoBehaviour {

	private UnitManager unitManager;

	public int numUnitsNeeded = 10;
	public int currentUnits = 0;

	public GameObject friendlyUnit;

	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update(){
		if(currentUnits >= numUnitsNeeded){
			GameObject instance = Instantiate(friendlyUnit, transform.position, friendlyUnit.transform.rotation) as GameObject;
			Object.Destroy(gameObject);
		}
	}
	
	void RightClicked(){
		if(unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				if(unit != null){
					unit.SendMessage("CommandeerVehicle", gameObject, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	void UnitAddedToVehicle(){
		currentUnits++;
	}

}
