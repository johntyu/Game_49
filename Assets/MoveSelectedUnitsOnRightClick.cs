using UnityEngine;
using System.Collections;

public class MoveSelectedUnitsOnRightClick : MonoBehaviour {
	
	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void RightClicked(Vector3 clickPosition){
		foreach(GameObject unit in unitManager.GetSelectedUnits()){
			unit.SendMessage("MoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);	
		}
	}
	
}
