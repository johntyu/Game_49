using UnityEngine;
using System.Collections;

public class UnitDragSelection : MonoBehaviour {

	public bool selected = false;
	private UnitManager unitManager;
	
	private AttackMoveIndicatorScript attackMoveIndicator;
	private CreateSelectionBox selectionBox;

	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		attackMoveIndicator = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<AttackMoveIndicatorScript>();
		selectionBox = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CreateSelectionBox>();
	}

	void Update () {
		if(Input.GetMouseButton(0) && selectionBox.selecting && renderer.isVisible){
			Vector3 camPos = Camera.mainCamera.WorldToScreenPoint(transform.position);
			camPos.y = CreateSelectionBox.InvertMouseY(camPos.y);
			selected = CreateSelectionBox.selection.Contains(camPos);
		}else if(Input.GetMouseButton(0) && selectionBox.selecting && !renderer.isVisible){
			selected = false;
		}

		if(selected && selectionBox.selecting){
			unitManager.SelectAdditionalUnit(gameObject);
		}else if(selectionBox.selecting){
			unitManager.DeselectUnit(gameObject);
		}
	}
}
