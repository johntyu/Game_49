using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour {
	
	public float moveSpeed = 5.0f;
	public float goalRadius = 0.01f;
	public bool attackMoveOrder = false;
	public bool attacking = false;
	
	private Vector3 goal;
	private float t = 0.0f;
	private bool onGoal;
	
	public void AttackMoveOrder(Vector3 newGoal){
		goal = newGoal;
		t = 0.0f;
		onGoal = false;
		attackMoveOrder = true;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
	}
	
	public void MoveOrder(Vector3 newGoal){
		goal = newGoal;
		t = 0.0f;
		onGoal = false;
		attackMoveOrder = false;
		gameObject.SendMessage("setEnemySelectedWithClick", false);
	}
	
	public void EnemyMoveOrder(Vector3 newGoal){
		goal = newGoal;
		t = 0.0f;
		onGoal = false;
		attackMoveOrder = false;
		gameObject.SendMessage("setEnemySelectedWithClick", true);
	}
	
	public void StopMoveOrder(){
		goal = transform.position;
		onGoal = true;
	}
	
	void Start(){
		goal = transform.position;
		onGoal = true;
	}
	
	void Update(){
	
		if(attackMoveOrder){
			GameObject targetEnemy = transform.GetComponent<ShootAtUnitsInRange>().targetEnemy;
			if(targetEnemy != null){
				attacking = true;
			}else{
				attacking = false;
			}
			
			if(!attacking){
				transform.position += (goal - transform.position).normalized * moveSpeed * Time.deltaTime;
			}
		}
		
		if(!attackMoveOrder){
			transform.position += (goal - transform.position).normalized * moveSpeed * Time.deltaTime;
		}
			
		if(!onGoal){
			foreach(Collider obj in Physics.OverlapSphere(goal, goalRadius)){
				if(obj.gameObject == gameObject){
					t += Time.deltaTime;
				}
			}
		}
		
		if(t > (0.5f/moveSpeed)){
			transform.position = goal;
			onGoal = true;
		}
	}
	
}
