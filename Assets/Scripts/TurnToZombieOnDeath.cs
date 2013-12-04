using UnityEngine;
using System.Collections;

public class TurnToZombieOnDeath : MonoBehaviour {

	private CivilianManager civManager;
	private UnitManager unitManager;

	public float curHealth = 20.0f;
	public float maxHealth = 20.0f;

	public GameObject zombieUnit;
	
	// Use this for initialization
	void Start () {
		civManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<CivilianManager>();
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0.0f){
			if(unitManager.NumUnits() < unitManager.numUnitsAllowed){
				GameObject instance = Instantiate(zombieUnit, transform.position, zombieUnit.transform.rotation) as GameObject;
				unitManager.SelectAdditionalUnit(instance);
				unitManager.AddUnit();
			}
			if(gameObject.name.Contains("Civilian")){
				civManager.RemoveCivilian();
			}
			Object.Destroy(gameObject);
		}
	}
	
	void BulletCollision(float damage){
		curHealth -= damage;
	}

}
