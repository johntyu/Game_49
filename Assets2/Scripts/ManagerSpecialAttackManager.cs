using UnityEngine;
using System.Collections;

public class ManagerSpecialAttackManager : MonoBehaviour {

	private UnitManager unitManager;
	
	private bool pressedA;
	private bool qDown;
	private bool wDown;
	private bool eDown;
	private bool rDown;

	public Texture2D defaultCursor;
	public Texture2D attackCursor;
	public Texture2D qCursor;
	public Texture2D wCursor;
	public Texture2D eCursor;
	public Texture2D rCursor;

	private bool special;

	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();

		Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

		pressedA = qDown = wDown = eDown = rDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			wDown = eDown = rDown = false;
			qDown = !qDown;
		}
		else if (Input.GetKeyDown(KeyCode.W)) {
			qDown = eDown = rDown = false;
			wDown = !wDown;
		}
		else if (Input.GetKeyDown(KeyCode.E)) {
			qDown = wDown = rDown = false;
			eDown = !eDown;
		}
		else if (Input.GetKeyDown(KeyCode.R)) {
			qDown = wDown = eDown = false;
			rDown = !rDown;
		}

		special = qDown || wDown || eDown || rDown;
		
		if (pressedA){
			Cursor.SetCursor(attackCursor, Vector2.zero, CursorMode.Auto);
		}
		else if (qDown) {
			Cursor.SetCursor(qCursor, Vector2.zero, CursorMode.Auto);
		}
		else if (wDown) {
			Cursor.SetCursor(wCursor, Vector2.zero, CursorMode.Auto);
		}
		else if (eDown) {
			Cursor.SetCursor(eCursor, Vector2.zero, CursorMode.Auto);
		}
		else if (rDown) {
			Cursor.SetCursor(rCursor, Vector2.zero, CursorMode.Auto);
		}
		else {
			Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
		}

		if (! special) {
			// if special isn't active, we don't want to do any more
			return;
		}

		if (Input.GetMouseButtonDown(0)) {
			foreach(GameObject unit in unitManager.GetSelectedUnits()){
				if(unit != null){
					if (qDown) {
						unit.SendMessage("SpecialAttack_Q", SendMessageOptions.DontRequireReceiver);
					}
					else if (wDown) {
						unit.SendMessage("SpecialAttack_W", SendMessageOptions.DontRequireReceiver);
					}
					else if (eDown) {
						unit.SendMessage("SpecialAttack_E", SendMessageOptions.DontRequireReceiver);
					}
					else if (rDown) {
						unit.SendMessage("SpecialAttack_R", SendMessageOptions.DontRequireReceiver);
					}
				}
			}

			qDown = wDown = eDown = rDown = false;
		}
	}
	
	void SwitchAOnOff(bool tmpA){
		pressedA = tmpA;
	}
}
