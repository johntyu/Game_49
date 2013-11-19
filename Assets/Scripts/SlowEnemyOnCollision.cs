using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowEnemyOnCollision : MonoBehaviour {
	
	public float radius = 3.2f;
	public float bulletDamage = 1.0f;
	public LayerMask mask;
	public float aoeRadius;
	private GameObject targetEnemy;
	//private List<GameObject> alreadyHitEnemy;
		
	float destroyTime = 4.0f;
	float curTime = 0.0f;
	
	void Start () {
		radius = 3.2f;
	    destroyTime = 6.0f;
		curTime = 0.0f;
	}
	
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);		
		
		if(enemyArray.Length > 0) {
			for(int i = 0; i < enemyArray.Length; i++) {
				targetEnemy = enemyArray[i].gameObject;
				targetEnemy.SendMessage("BulletCollision", bulletDamage);
				targetEnemy.SendMessage("slowtriggerEffect", targetEnemy);
				Object.Destroy(gameObject);
			}
		}
		
		curTime += Time.deltaTime;
		if(curTime > destroyTime){
			Object.Destroy(gameObject);
		}
	}
}