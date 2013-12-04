using UnityEngine;
using System.Collections;

public class MoveSelectedUnitsOnRightClick : MonoBehaviour {
	
	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void RightClicked(Vector3 clickPosition){
		if(transform.gameObject.layer == 10){	
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				if(unit != null){
					unit.SendMessage("AttackMoveOrder",
				    	             new Vector3(clickPosition.x, clickPosition.y - 80.0f, clickPosition.z),
				        	         SendMessageOptions.DontRequireReceiver);
				}
			}
		}else{
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				if(unit != null){
					unit.SendMessage("MoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
	
}
