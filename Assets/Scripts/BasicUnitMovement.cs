using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	private UnitManager unitManager;
	
	public float moveSpeed = 5.0f;
	public bool attackMoveOrder = false;
	public bool attacking = false;
	
	private Vector3 currentGoal;
	private bool onGoal = true;
	private float stopTimeInc = 0.0f;
	private float stopTime = 1.0f;

	void Start(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}
	
	public void AttackMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		navMeshAgent.SetDestination(newGoal);
		attackMoveOrder = true;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
	}
	
	public void MoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
		navMeshAgent.SetDestination(newGoal);
		attackMoveOrder = false;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
	}
	
	public void EnemyMoveOrder(Vector3 newGoal){
		stopTimeInc = 0.0f;
		currentGoal = newGoal;
		onGoal = false;
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
		GameObject targetEnemy = transform.GetComponent<ShootAtUnitsInRange>().targetEnemy;
		if(targetEnemy != null){
			attacking = true;
		}else{
			attacking = false;
		}
			
		if(attacking && attackMoveOrder){
			navMeshAgent.speed = 0;
		}else{
			navMeshAgent.speed = moveSpeed;
		}
	}
	
}
