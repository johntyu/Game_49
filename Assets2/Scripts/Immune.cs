using UnityEngine;
using System.Collections;

public class Immune : MonoBehaviour {
	
	public LayerMask mask;
	public float radius;
	public bool triggerImmune;
	public float immuneStart;
	public float immuneEnd;
	
	
	public bool Recaller;
	void Start () {
		immuneStart = 0.0f;
		immuneEnd = 2.0f;
		triggerImmune = false;
	}
	
	// Update is called once per frame
	void Update () {
		getImmune();
		doImmune();
	}
	
	
	public void doImmune() {
		if(triggerImmune == true) {
			//If mouse click recall your units
			immuneStart += Time.deltaTime;
			if(immuneStart > immuneEnd) {
				triggerImmune = false;
				gameObject.SendMessage("setImmune", false);
				
			}
 		}	
	}
	
	
	
	
	public void getImmune() {
		
		if(Input.GetKeyUp(KeyCode.Q) && triggerImmune == false){
			Debug.Log("hello i");
			triggerImmune = true;
			gameObject.SendMessage("setImmune", true);
			
		}
	}
		
}
