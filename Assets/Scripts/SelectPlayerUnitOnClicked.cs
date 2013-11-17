using UnityEngine;
using System.Collections;

public class SelectPlayerUnitOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update(){
		
	}
	
	void Clicked(){
		if(Input.GetKey (KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
			unitManager.SelectAdditionalUnit(gameObject);
		}else{
			unitManager.SelectSingleUnit(gameObject);
		}
	}
	
}
