using UnityEngine;
using System.Collections;

public class SelectPlayerUnitOnTrigger : MonoBehaviour {

	private UnitManager unitManager;
	public string[] tags;
	
	void Start(){
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	void OnTriggerEnter(Collider col){
		if(gameObject.layer != 9) {
			return;
		}

		foreach(string tag in tags){
			if(col.tag == tag){
				unitManager.SelectAdditionalUnit(gameObject);
				return;
			}
		}
	}
	
	void OnTriggerExit(Collider col){
		foreach(string tag in tags){
			if(col.tag == tag){
				unitManager.DeselectUnit(gameObject);
				return;
			}
		}
	}
}
