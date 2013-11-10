using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {
	
	public float curHealth = 20.0f;
	public float maxHealth = 20.0f;
	
	private UnitManager unitManager;
	
	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0.0f){
			unitManager.DeselectUnit(gameObject);
			Object.Destroy(gameObject);
		}
	}
	
	void BulletCollision(float damage){
		curHealth -= damage;
	}
}
