using UnityEngine;
using System.Collections;

public class CarHealth : MonoBehaviour {
	
	public float curHealth = 20.0f;
	public float maxHealth = 20.0f;

	public float curInfect = 20.0f;
	public bool IsImmune;
	private UnitManager unitManager;
	
	// Use this for initialization
	void Start () {
		curHealth = 50.0f;
		maxHealth = 50.0f;
		curInfect = 100.0f;
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0.0f){
			unitManager.DeselectUnit(gameObject);
			Object.Destroy(gameObject);
		}


	}
	
	public void BulletCollision(float damage){
		curHealth -= damage/2;
	}

	public void InfectCollision(float damage){
		curInfect -= damage;
		if (curInfect <= 0.0f) {
			gameObject.SendMessage("setMaskToEnemy");
		}
	}

	
	public void setImmune(bool inImmune) {
		IsImmune = inImmune;
	}
	
	
	void HealUnit(float healpoints) {
		curHealth += healpoints;
		
		if(curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		
	}
}
