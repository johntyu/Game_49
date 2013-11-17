using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserEnemyOnCollision : MonoBehaviour {
	
	public float radius = 0.2f;
	public float bulletDamage = 5.0f;
	public LayerMask mask;
	private GameObject targetEnemy;
	private List<GameObject> alreadyHitEnemy;
		
	float destroyTime = 6.0f;
	float curTime = 0.0f;
	
	void Start () {
		float destroyTime = 6.0f;
		curTime = 0.0f;
		alreadyHitEnemy = new List<GameObject>();
	}
	
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);		
		
		if(enemyArray.Length > 0) {
			for(int i = 0; i < enemyArray.Length; i++) {
				
				targetEnemy = enemyArray[i].gameObject;
				if(alreadyHitEnemy.Contains(targetEnemy)) {
					continue;	
				}
				else {
					alreadyHitEnemy.Add(targetEnemy);
					targetEnemy.SendMessage("BulletCollision", bulletDamage);
				}
				//Object.Destroy(gameObject);
			}
		}
		
		curTime += Time.deltaTime;
		if(curTime > destroyTime){
			Object.Destroy(gameObject);
		}	
	}
}