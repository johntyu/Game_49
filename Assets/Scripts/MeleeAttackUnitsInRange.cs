using UnityEngine;
using System.Collections;

public class MeleeAttackUnitsInRange : MonoBehaviour {

	public float meleeDamage;
	public float fireDelay;
	public float radius;
	public LayerMask mask;
	
	public GameObject targetEnemy;
	public GameObject selectedEnemy;
	public bool enemySelectedWithClick;
	public bool commandeerEnemy;
	private float fireTime;
	
	public bool isLockdown;
	public float lockdownStart;
	public float lockdownEnd;

	private UnitManager unitManager;

	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		fireTime = 0.0f;
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
				enemyInRange = true;
			}
		}
		
		if(selectedEnemy == null){
			enemySelectedWithClick = false;
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
				targetEnemy.SendMessage("BulletCollision", meleeDamage);
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

		if(commandeerEnemy && selectedEnemy != null){
			if(Vector3.Distance(selectedEnemy.transform.position, gameObject.transform.position) < 1.0f){
				selectedEnemy.SendMessage("UnitAddedToVehicle", SendMessageOptions.DontRequireReceiver);
				unitManager.DeselectUnit(gameObject);
				GameObject.Destroy(gameObject);
			}
		}
	}
	
	void SetEnemySelectedWithClick(bool a){
		enemySelectedWithClick = a;
	}
	
	void SetSelectedEnemyWithClick(GameObject enemy){
		selectedEnemy = enemy;
		gameObject.SendMessage("EnemyMoveOrder", enemy.transform.position);
	}
	
	void CommandeerVehicle(GameObject enemy){
		selectedEnemy = enemy;
		commandeerEnemy = true;
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
	
}
