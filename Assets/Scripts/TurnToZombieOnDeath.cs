using UnityEngine;
using System.Collections;

public class TurnToZombieOnDeath : MonoBehaviour {
	
	public float curHealth = 20.0f;
	public float maxHealth = 20.0f;

	public GameObject zombieUnit;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0.0f){
			GameObject instance = Instantiate(zombieUnit, transform.position, zombieUnit.transform.rotation) as GameObject;
			Object.Destroy(gameObject);
		}
	}
	
	void BulletCollision(float damage){
		curHealth -= damage;
	}

}
