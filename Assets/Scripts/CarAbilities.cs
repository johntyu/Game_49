using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarAbilities : MonoBehaviour {

	public GameObject friendlyAttacker;
	public GameObject neutralCar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void UnloadAll(){
		for(int i = 0; i < 10; i++){
			Instantiate(friendlyAttacker, transform.position, friendlyAttacker.transform.rotation);
		}
	}

	void SpecialAttack_R(){
		for(int i = 0; i < 10; i++){
			Instantiate(friendlyAttacker, transform.position, friendlyAttacker.transform.rotation);
		}
		Instantiate(neutralCar, transform.position, neutralCar.transform.rotation);
		GameObject.Destroy(gameObject);
	}
}
