using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

	public LayerMask mask;
	public float radius;
	public GameObject targetAlly;
	public bool Healer;
	public float healAmount;

	private float coolDownEnd = 2.0f;
	private float coolDownStart = 0.0f;
	
	public bool Recaller;
	void Start () {
		Healer = false;
		radius = 5;
		healAmount = 5;
	}
	
	// Update is called once per frame
	void Update () {
		getHeal();
		doHeal();
		coolDownStart += Time.deltaTime;
	}
	
	
	public void doHeal() {
		if(Healer == true) {
			//If mouse click recall your units
			Healer = false;
			Collider[] healArray = Physics.OverlapSphere(transform.position, radius, mask);
			
			if(coolDownStart > coolDownEnd){
				coolDownStart = 0.0f;
				if(healArray.Length > 0) {
					for(int i = 0; i < healArray.Length; i++) {			
						targetAlly = healArray[i].gameObject;
						targetAlly.SendMessage("HealUnit", healAmount);	
					}
				}
			}		
		}
		
	}
	
	
	
	
	public void getHeal() {
		
		if(Input.GetKeyUp(KeyCode.H) && Healer == false){
			Debug.Log("hello h");
			Healer = true;
		}
	}
		
}
