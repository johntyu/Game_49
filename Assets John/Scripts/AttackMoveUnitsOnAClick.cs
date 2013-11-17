using UnityEngine;
using System.Collections;

public class AttackMoveUnitsOnAClick : MonoBehaviour {
	
	private UnitManager unitManager;
	private ShowOnAttackMove showOnAttackMove;
	public bool pressedA = false;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		showOnAttackMove = GameObject.FindGameObjectWithTag("AttackMoveIndicator").GetComponent<ShowOnAttackMove>();
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.A)){
			pressedA = !pressedA;
			showOnAttackMove.SendMessage("SwitchOnOff", pressedA);
		}
	}
	
	void Clicked(Vector3 clickPosition){
		if(!pressedA){
			unitManager.DeselectAllUnits();
		}
		if(pressedA && unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("AttackMoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);	
			}
		}
		pressedA = false;
		showOnAttackMove.SendMessage("SwitchOnOff", pressedA);
	}
	
}
