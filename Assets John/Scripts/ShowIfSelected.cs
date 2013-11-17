using UnityEngine;
using System.Collections;

public class ShowIfSelected : MonoBehaviour {
	
	private UnitManager unitManager;
	
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void Update(){
		if(unitManager.IsSelected(transform.parent.gameObject)){
			renderer.enabled = true;
		}else{
			renderer.enabled = false;
		}
	}
}
