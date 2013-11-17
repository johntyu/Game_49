using UnityEngine;
using System.Collections;

public class ManagerSpecialAttackManager : MonoBehaviour {

	private UnitManager unitManager;

	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		bool q = Input.GetKeyDown(KeyCode.Q);
		bool w = Input.GetKeyDown(KeyCode.W);
		bool e = Input.GetKeyDown(KeyCode.E);
		bool r = Input.GetKeyDown(KeyCode.R);

		foreach(GameObject unit in unitManager.GetSelectedUnits()){
			if (q) {
				unit.SendMessage("SpecialAttack_Q", SendMessageOptions.DontRequireReceiver);
			}
			if (w) {
				unit.SendMessage("SpecialAttack_W", SendMessageOptions.DontRequireReceiver);
			}
			if (e) {
				unit.SendMessage("SpecialAttack_E", SendMessageOptions.DontRequireReceiver);
			}
			if (r) {
				unit.SendMessage("SpecialAttack_R", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
