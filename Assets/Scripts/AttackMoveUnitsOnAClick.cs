using UnityEngine;
using System.Collections;

public class AttackMoveUnitsOnAClick : MonoBehaviour {
	
	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update(){
		
	}
	
	void Clicked(Vector3 clickPosition){
		bool pressedA = transform.parent.GetComponent<AttackMoveIndicatorScript>().pressedA;
		if(!pressedA){
			unitManager.DeselectAllUnits();
		}else if(pressedA && unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("AttackMoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);	
			}
		}
		transform.parent.SendMessage("SetPressedA", false);
	}
	
}
