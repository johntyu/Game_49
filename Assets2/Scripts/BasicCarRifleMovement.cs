using UnityEngine;
using System.Collections;

public class BasicCarRifleMovement : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	private UnitManager unitManager;
	
	public float moveSpeed = 8.0f;
	public bool attackMoveOrder = false;
	public bool attacking = false;
	
	private Vector3 currentGoal;
	private bool onGoal = true;
	private float stopTimeInc = 0.0f;
	private float stopTime = 1.0f;
	private bool foundGoal = true;
	
	void Start(){
		moveSpeed = 8.0f;
		navMeshAgent = GetComponent<NavMeshAgent>();
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	public void startSlow() {
		moveSpeed = 5.0f;	
	}
	
	public void endSlow() {
		moveSpeed = 7.0f;	
	}
	
	public void AttackMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		foundGoal = false;
		navMeshAgent.SetDestination(newGoal);
		attackMoveOrder = true;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
		
		
		
	}
	
	public void MoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		foundGoal = false;
		navMeshAgent.SetDestination(newGoal);
		attackMoveOrder = false;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
		
		
		
	}
	
	public void EnemyMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		foundGoal = false;
		navMeshAgent.SetDestination(newGoal);
		attackMoveOrder = false;
		gameObject.SendMessage("setEnemySelectedWithClick", true);
		
		
	}
	
	public void StopMoveOrder(){
		currentGoal = transform.position;
		onGoal = true;
		navMeshAgent.SetDestination(transform.position);
		attackMoveOrder = false;
	}
	
	void FixedUpdate(){
		
		if(navMeshAgent.hasPath && !foundGoal){
			foundGoal = true;
			stopTime = navMeshAgent.remainingDistance / 3.0f;
		}
		
		
		GameObject car = null;
		foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
			if(child.name.IndexOf("car") != -1){
				car = child.gameObject;
			}
		}
		
		//rotate car model to look at where it is firing
		float rotationVal = Vector3.Angle(new Vector3(0.0f, 0.0f, 1.0f), (currentGoal - transform.position));
		if(currentGoal.x < transform.position.x){
			if(car != null){
				car.transform.rotation = Quaternion.Euler(270.0f, -1*rotationVal, 0);
			}
		}else{
			if(car != null){
				car.transform.rotation = Quaternion.Euler(270.0f, rotationVal, 0);
			}
		}
		
		
		GameObject targetEnemy = transform.GetComponent<CarShootRifle>().targetEnemy;
		if(targetEnemy != null){
			attacking = true;
		}else{
			attacking = false;
		}
		
		if(attacking && attackMoveOrder){
			navMeshAgent.speed = 0;
		}else{
			navMeshAgent.speed = moveSpeed;
			stopTimeInc += Time.fixedDeltaTime;
		}
		
		if(stopTimeInc > stopTime){
			//StopMoveOrder();
		}
	}
	
}
