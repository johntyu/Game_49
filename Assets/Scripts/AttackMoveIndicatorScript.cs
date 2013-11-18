using UnityEngine;
using System.Collections;

public class AttackMoveIndicatorScript : MonoBehaviour {
	
	public bool pressedA = false;
	private ShowOnAttackMove showOnAttackMove;
	private ManagerSpecialAttackManager unitManager;
	
	// Use this for initialization
	void Start () {
		showOnAttackMove = GameObject.FindGameObjectWithTag("AttackMoveIndicator").GetComponent<ShowOnAttackMove>();
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<ManagerSpecialAttackManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			pressedA = !pressedA;
		}
		showOnAttackMove.SendMessage("SwitchOnOff", pressedA);
		unitManager.SendMessage("SwitchAOnOff", pressedA);
	}
	
	void SetPressedA(bool newA){
		pressedA = newA;
	}
}
