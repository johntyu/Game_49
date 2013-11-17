using UnityEngine;
using System.Collections;

public class DamageEnemyOnCollision : MonoBehaviour {
	
	public float radius;
	public float bulletDamage;
	public LayerMask mask;
	private GameObject targetEnemy;
	
	void Start () {
		bulletDamage = 5.0f;
		radius = 0.2f;
	}
	
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);
		if(enemyArray.Length > 0){
			targetEnemy = enemyArray[0].gameObject;
			targetEnemy.SendMessage("BulletCollision", bulletDamage);
			Object.Destroy(gameObject);
		}
		
	}
}
