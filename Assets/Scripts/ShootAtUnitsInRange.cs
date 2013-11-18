using UnityEngine;
using System.Collections;

public class ShootAtUnitsInRange : MonoBehaviour {
	
	public GameObject bullet;
	public float speed;
	public float fireDelay;
	public float radius;
	public LayerMask mask;
	
	public GameObject targetEnemy;
	public GameObject selectedEnemy;
	private bool enemySelectedWithClick;
	private float fireTime;
	
	void Start () {
		speed = 500.0f;
		fireDelay = 1.0f;
		fireTime = 0.0f;
		radius = 5.0f;
	}
	
	void Update () {
		fireTime += Time.deltaTime;
		
		//get array of all enemies in range
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);
		
		bool enemyInRange = false;
		foreach(Collider enemy in enemyArray){
			//check if target enemy is still in range
			if(targetEnemy != null){
				if(targetEnemy == enemy.gameObject){
					enemyInRange = true;
				}
			}
			//if selected enemy in range, fire at him and stop moving
			if(enemy.gameObject == selectedEnemy){
				targetEnemy = selectedEnemy;
				selectedEnemy = null;
				enemySelectedWithClick = false;
				gameObject.SendMessage("StopMoveOrder");
			}
		}
		
		//if enemy is out of range, stop firing
		if(!enemyInRange){
			targetEnemy = null;
		}
		
		//if no target enemy, get the first one in range
		if(targetEnemy == null){
			if(enemyArray.Length > 0 && !enemySelectedWithClick){
				targetEnemy = enemyArray[0].gameObject;
			}else if(!enemySelectedWithClick){
				targetEnemy = null;
			}
		}
		
		//fire bullet at enemy every fireDelay seconds
		if(targetEnemy != null){
			if (fireTime > fireDelay) {
				fireTime = 0.0f;
				GameObject instance = Instantiate(bullet, transform.position, bullet.transform.rotation) as GameObject;
				if(instance.rigidbody){
					instance.rigidbody.AddForce((targetEnemy.transform.position - transform.position).normalized * speed / 50.0f, ForceMode.VelocityChange);
				}
			}
			
			//get turret model as a game object
			GameObject turret = null;
			foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
				if(child.name == "Turret"){
					turret = child.gameObject;
				}
			}

			//rotate turret model to look at where it is firing
			float rotationVal = Vector3.Angle(new Vector3(0.0f, 0.0f, 1.0f), (targetEnemy.transform.position - transform.position));
			if(targetEnemy.transform.position.x < transform.position.x){
				if(turret != null){
					turret.transform.rotation = Quaternion.Euler(0, -1*rotationVal, 0);
				}
			}else{
				if(turret != null){
					turret.transform.rotation = Quaternion.Euler(0, rotationVal, 0);
				}
			}
		}		
	}
	
	void setEnemySelectedWithClick(bool a){
		enemySelectedWithClick = a;
	}
	
	void SetSelectedEnemyWithClick(GameObject enemy){
		selectedEnemy = enemy;
		gameObject.SendMessage("EnemyMoveOrder", enemy.transform.position);
	}

	void setEnemyWhenAttacked(GameObject enemy) {
		if (selectedEnemy == null && targetEnemy == null) {
			targetEnemy = enemy;
		}
	}
}
