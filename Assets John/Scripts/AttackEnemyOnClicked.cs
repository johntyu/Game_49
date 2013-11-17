using UnityEngine;
using System.Collections;

public class AttackEnemyOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update(){
		
	}
	
	void RightClicked(){
		if(unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("SetSelectedEnemyWithClick", gameObject, SendMessageOptions.DontRequireReceiver);	
			}
		}
	}
	
}


