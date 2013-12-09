using UnityEngine;
using System.Collections;

public class SelectPlayerUnitOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	private float doubleClickStart;

	private PauseMenuGUI pauseMenu;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PauseMenuGUI>();
		doubleClickStart = 0.0f;
	}
	
	void Update(){
		doubleClickStart += Time.deltaTime;
	}
	
	void Clicked(){
		if(doubleClickStart < 0.3f){
			DoubleClicked();
		}else if (!pauseMenu.paused){
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
