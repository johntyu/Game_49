using UnityEngine;
using System.Collections;

public class InfectEnemyOnCollision : MonoBehaviour {
	
	public float radius = 0.2f;
	public float bulletDamage = 5.0f;
	public LayerMask mask;
	
	private GameObject targetEnemy;
	private GameObject shooter;
	
	void Start () {
		float bulletDamage = 4.0f;
	}
	
	void setShooter(GameObject shooter_) {
		shooter = shooter_;
	}
	
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);
		if(enemyArray.Length > 0){
			targetEnemy = enemyArray[0].gameObject;

			if(targetEnemy.transform.name.IndexOf("Enemy_Car") != -1) {
				targetEnemy.SendMessage("InfectCollision", 30);
			}
			else {
				targetEnemy.SendMessage("BulletCollision", bulletDamage);
			}
			
			
			//targetEnemy.SendMessage("setEnemyWhenAttacked", shooter);
			Object.Destroy(gameObject);
		}
	}
}

