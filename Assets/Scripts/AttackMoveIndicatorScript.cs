using UnityEngine;
using System.Collections;

public class AttackMoveIndicatorScript : MonoBehaviour {
	
	public bool pressedA = false;
	private ShowOnAttackMove showOnAttackMove;
	
	// Use this for initialization
	void Start () {
		showOnAttackMove = GameObject.FindGameObjectWithTag("AttackMoveIndicator").GetComponent<ShowOnAttackMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			pressedA = !pressedA;
		}
		showOnAttackMove.SendMessage("SwitchOnOff", pressedA);
	}
	
	void SetPressedA(bool newA){
		pressedA = newA;
	}
}
