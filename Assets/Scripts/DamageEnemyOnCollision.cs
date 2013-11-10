using UnityEngine;
using System.Collections;

public class DamageEnemyOnCollision : MonoBehaviour {
	
	public float radius = 0.2f;
	public float bulletDamage = 5.0f;
	public LayerMask mask;
	
	private GameObject targetEnemy;
	
	void Start () {
		
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
