using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	private UnitManager unitManager;

	public float defaultSpeed = 5.0f;
	public float moveSpeed = 5.0f;
	public bool attackMoveOrder = false;
	public bool attacking = false;
	
	private Vector3 currentGoal;
	private bool onGoal = true;
	private float stopTimeInc = 0.0f;
	private float stopTime = 1.0f;
	private bool foundGoal = true;

	//
	public float changeDirectionPerMinute = 30.0f;
	private float changeDirectionTime = 0.0f;
	private Vector3 randomPoint;

	void Start(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		currentGoal = transform.position;
		//
		randomPoint = transform.position + new Vector3(Random.value * 100 - 50.0f, 0.0f, Random.value * 100 - 50.0f);
	}

	public void startSlow() {
		moveSpeed = defaultSpeed / 5.0f;	
	}
	
	public void endSlow() {
		moveSpeed = defaultSpeed;	
	}
	
	public void AttackMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		stopTime = (newGoal - transform.position).magnitude / 4.0f;
		int numUnits = unitManager.getNumSelectedUnits();
		float r = Mathf.Sqrt(numUnits) * 2.0f;
		currentGoal = newGoal + new Vector3((Random.value * r) - (r / 2.0f), 0.0f, (Random.value * r) - (r / 2.0f));
		onGoal = false;
		foundGoal = false;
		navMeshAgent.SetDestination(currentGoal);
		attackMoveOrder = true;
		gameObject.SendMessage("SetEnemySelectedWithClick", false, SendMessageOptions.DontRequireReceiver);
	}
	
	public void MoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		stopTime = (newGoal - transform.position).magnitude / 4.0f;
		int numUnits = unitManager.getNumSelectedUnits();
		float r = Mathf.Sqrt(numUnits) * 2.0f;
		currentGoal = newGoal + new Vector3((Random.value * r) - (r / 2.0f), 0.0f, (Random.value * r) - (r / 2.0f));
		onGoal = false;
		foundGoal = false;
		navMeshAgent.SetDestination(currentGoal);
		attackMoveOrder = false;
		gameObject.SendMessage("SetEnemySelectedWithClick", false, SendMessageOptions.DontRequireReceiver);
	}
	
	public void EnemyMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		foundGoal = false;	
		navMeshAgent.SetDestination(currentGoal);
		attackMoveOrder = true;
		gameObject.SendMessage("SetEnemySelectedWithClick", true, SendMessageOptions.DontRequireReceiver);
	}
	
	public void StopMoveOrder(){
		//currentGoal = transform.position;
		onGoal = true;
		navMeshAgent.ResetPath();
		attackMoveOrder = false;
	}
	
	void Update(){

		if(navMeshAgent.hasPath && !foundGoal){
			foundGoal = true;
		}

		GameObject targetEnemy = null;
		GameObject selectedEnemy = null;
		bool enemySelectedWithClick = false;
		bool commanderEnemy = false;
		if(gameObject.GetComponent<MeleeAttackUnitsInRange>() != null){
			targetEnemy = transform.GetComponent<MeleeAttackUnitsInRange>().targetEnemy;
			enemySelectedWithClick = transform.GetComponent<MeleeAttackUnitsInRange>().enemySelectedWithClick;
		}else if(gameObject.GetComponent<ShootAtUnitsInRange>() != null){
	 		targetEnemy = transform.GetComponent<ShootAtUnitsInRange>().targetEnemy;
			enemySelectedWithClick = transform.GetComponent<ShootAtUnitsInRange>().enemySelectedWithClick;
		}
		if(targetEnemy != null){
			attacking = true;
		}else{
			attacking = false;
		}

		if(enemySelectedWithClick){
			if(gameObject.GetComponent<MeleeAttackUnitsInRange>() != null){
				selectedEnemy = transform.GetComponent<MeleeAttackUnitsInRange>().selectedEnemy;
				commanderEnemy = transform.GetComponent<MeleeAttackUnitsInRange>().commandeerEnemy;
			}else if(gameObject.GetComponent<ShootAtUnitsInRange>() != null){
				selectedEnemy = transform.GetComponent<ShootAtUnitsInRange>().selectedEnemy;
				commanderEnemy = transform.GetComponent<ShootAtUnitsInRange>().commandeerEnemy;
			}
			if(selectedEnemy != null){
				if(selectedEnemy.transform.position != currentGoal){
					EnemyMoveOrder(selectedEnemy.transform.position);
				}
			}
		}
		
		int numUnits = unitManager.getNumSelectedUnits();
		float r = Mathf.Sqrt(numUnits) * 2.0f;
		if(navMeshAgent.hasPath && !foundGoal){
			if((navMeshAgent.remainingDistance / 4.0f) > stopTime){
				stopTime = navMeshAgent.remainingDistance / 4.0f;
				stopTimeInc = 0.0f;
			}
		}

		if(attacking && attackMoveOrder){
			navMeshAgent.speed = 0;
		}else{
			navMeshAgent.speed = moveSpeed;
			stopTimeInc += Time.deltaTime;
		}

		if(stopTimeInc > stopTime){
			StopMoveOrder();
		}

		//
		changeDirectionTime += Time.deltaTime;
		if(onGoal){
			transform.position += (randomPoint - transform.position).normalized * moveSpeed/16.0f * Time.deltaTime;

			int numUnits2 = unitManager.getNumSelectedUnits();
			float r2 = Mathf.Sqrt(numUnits) * 2.0f;
			if(changeDirectionTime >= (60.0f / changeDirectionPerMinute)){
				changeDirectionTime = 0.0f;
				randomPoint = currentGoal + new Vector3((Random.value * r2) - (r2 / 2.0f), 0.0f, (Random.value * r2) - (r2 / 2.0f));
			}
		}
	}
	
}
