using UnityEngine;
using System.Collections;

public class AoeEnemyOnCollision : MonoBehaviour {
	
	public float radius = 0.2f;
	public float bulletDamage = 5.0f;
	public LayerMask mask;
	public float aoeRadius;
	private GameObject targetEnemy;
	
	void Start () {
		aoeRadius = 2;
	}
	
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);		
		
		if(enemyArray.Length > 0) {
			
			Collider[] enemyArray2 = Physics.OverlapSphere(transform.position, aoeRadius, mask);
			Debug.Log ("Length is: " + enemyArray2.Length);
			for(int i = 0; i < enemyArray2.Length; i++) {
				targetEnemy = enemyArray2[i].gameObject;
				targetEnemy.SendMessage("BulletCollision", bulletDamage);
				Object.Destroy(gameObject);
			}
		}
	}
}