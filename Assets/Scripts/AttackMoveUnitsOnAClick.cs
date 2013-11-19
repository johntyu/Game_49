using UnityEngine;
using System.Collections;

public class AttackMoveUnitsOnAClick : MonoBehaviour {
	
	private UnitManager unitManager;
	private AttackMoveIndicatorScript attackMoveIndicator;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		attackMoveIndicator = GameObject.FindGameObjectWithTag("AttackMoveIndicatorManager").GetComponent<AttackMoveIndicatorScript>();
	}
	
	void Update(){
		
	}
	
	void Clicked(Vector3 clickPosition){
		bool pressedA = attackMoveIndicator.pressedA;
		if(!pressedA){
			unitManager.DeselectAllUnits();
		}else if(pressedA && unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("AttackMoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);	
			}
		}
		attackMoveIndicator.SendMessage("SetPressedA", false);
	}
	
}
