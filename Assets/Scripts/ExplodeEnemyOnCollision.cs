using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodeEnemyOnCollision : MonoBehaviour {
	
	public float radius = 0.5f;
	public float bulletDamage = 30.0f;
	public LayerMask mask;
	private GameObject targetEnemy;
	//private List<GameObject> alreadyHitEnemy;
	public GameObject explosion;	
	
	float destroyTime = 4.0f;
	float curTime = 0.0f;
	
	void Start () {
		radius = 2.5f;
		destroyTime = 6.0f;
		curTime = 0.0f;
		bulletDamage = 30.0f;
	}
	
	void Update () {
		curTime += Time.deltaTime;
		if(curTime > destroyTime){
			Object.Destroy(gameObject);
		}
		
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);		
		
		
		
		if(enemyArray.Length > 0) {
			for(int i = 0; i < enemyArray.Length; i++) {
				targetEnemy = enemyArray[i].gameObject;
			

				if(targetEnemy.transform.name.IndexOf("Enemy_Car") != -1) {
					targetEnemy.SendMessage("InfectCollision", 100);
				}
				else {
					targetEnemy.SendMessage("BulletCollision", bulletDamage);
				}

				GameObject instance = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
				//instance.SendMessage("igniteFire");	
				//if(instance.rigidbody){
				//	instance.SendMessage("igniteFire");	
				//}
				
				
				Object.Destroy(gameObject);
			}
		}
		
		
		
	}
}