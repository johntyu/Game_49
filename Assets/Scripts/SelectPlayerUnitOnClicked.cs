using UnityEngine;
using System.Collections;

public class SelectPlayerUnitOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	private float doubleClickStart;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		doubleClickStart = 0.0f;
	}
	
	void Update(){
		doubleClickStart += Time.deltaTime;
	}
	
	void Clicked(){
		if(gameObject.layer != 9) {
			return;
		}
		if(doubleClickStart < 0.3f){
			DoubleClicked();
		}else{
			if(Input.GetKey (KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
				unitManager.SelectAdditionalUnit(gameObject);
			}else{
				unitManager.SelectSingleUnit(gameObject);
			}
		}
		doubleClickStart = 0.0f;
	}
	
	void DoubleClicked(){
		unitManager.SelectAllUnitsOfType(gameObject);
	}
	
}
