using UnityEngine;
using System.Collections;

public class ShowOnAttackMove : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SwitchOnOff(bool switchOn){
		renderer.enabled = switchOn;
	}
}
