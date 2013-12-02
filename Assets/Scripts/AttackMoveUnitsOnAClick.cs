using UnityEngine;
using System.Collections;

public class AttackMoveUnitsOnAClick : MonoBehaviour {
	
	private UnitManager unitManager;
	private AttackMoveIndicatorScript attackMoveIndicator;
	
	private GameObject mainCamera;
	private Vector3 newCamPos;
	private bool newPos = false;

	private PauseMenuGUI pauseMenu;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		attackMoveIndicator = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<AttackMoveIndicatorScript>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		pauseMenu = mainCamera.GetComponent<PauseMenuGUI>();
	}
	
	void Update(){
		if(newPos){
			mainCamera.transform.position = newCamPos;
			newPos = false;
		}
	}
	
	void Clicked(Vector3 clickPosition){
		bool pressedA = attackMoveIndicator.pressedA;
		if(!pauseMenu.paused && !pressedA && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl) && gameObject.layer != 10){
			unitManager.DeselectAllUnits();
		}else if(pressedA && unitManager.UnitsAreSelected() && gameObject.layer == 10){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("AttackMoveOrder", 
				                 new Vector3(clickPosition.x, clickPosition.y - 80.0f, clickPosition.z),
				                 SendMessageOptions.DontRequireReceiver);	
			}
		}else if(pressedA && unitManager.UnitsAreSelected()){
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				unit.SendMessage("AttackMoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);	
			}
		}else if(gameObject.layer == 10){
			newCamPos = new Vector3(
				clickPosition.x,
				mainCamera.transform.position.y,
				clickPosition.z - 10.0f);
			newPos = true;
		}

		attackMoveIndicator.SendMessage("SetPressedA", false);
	}

}
