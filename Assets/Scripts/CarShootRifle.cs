using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class CarShootRifle : MonoBehaviour {

	public GameObject sparks;
	public float speed;
	public float fireDelay;
	public float radius;
	public LayerMask mask;
	public LayerMask mask2;
	
	public GameObject targetEnemy;
	public GameObject selectedEnemy;
	private bool enemySelectedWithClick;
	private float fireTime;
	
	public bool isLockdown;
	public float lockdownStart;
	public float lockdownEnd;
	
	
	void Start () {
		speed = 700.0f;
		fireDelay = 1.0f;
		fireTime = 0.0f;
		radius = 6.0f;
	}
	
	void Update () {
		//Debug.Log("MyMaskIs: " + mask);
		
		
		fireTime += Time.deltaTime;
		
		//get array of all enemies in range
		Collider[] enemyArray;
		
		if (gameObject.layer == 9) {
			enemyArray = Physics.OverlapSphere (transform.position, radius, mask);
		} 
		else {
			enemyArray = Physics.OverlapSphere (transform.position, radius, mask2);
		}
		
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
			if (fireTime > fireDelay && !isLockdown) {
				fireTime = 0.0f;
				targetEnemy.SendMessage("BulletCollision", 3);
				GameObject instance = Instantiate(sparks, targetEnemy.transform.position, targetEnemy.transform.rotation) as GameObject;

			}
			
			//get car model as a game object
			GameObject car = null;
			foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
				if(child.name.IndexOf("car") != -1){
					car = child.gameObject;
				}
			}
			
			//rotate car model to look at where it is firing
			float rotationVal = Vector3.Angle(new Vector3(0.0f, 0.0f, 1.0f), (targetEnemy.transform.position - transform.position));
			if(targetEnemy.transform.position.x < transform.position.x){
				if(car != null){
					car.transform.rotation = Quaternion.Euler(270.0f, -1*rotationVal, 0);
				}
			}else{
				if(car != null){
					car.transform.rotation = Quaternion.Euler(270.0f, rotationVal, 0);
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
	
	public void setLockdown(bool inLock) {
		isLockdown = true;
		lockdownStart = 0.0f;
	}
	
	public void maintainLockdown() {
		if(isLockdown == true) {
			lockdownStart += Time.deltaTime;
			
			if(lockdownStart > lockdownEnd) {
				isLockdown = false;
				lockdownStart = 0.0f;
			}
		}
	}
	
	public void setMaskToEnemy() {
		if(gameObject.layer == 9) {
			return;
		}
		Debug.Log("OldLayer: " + gameObject.layer);
		gameObject.layer = 9;
		Debug.Log("NewLayer: " + gameObject.layer);
		Debug.Log("Mask :" + mask);
	}
	
}
