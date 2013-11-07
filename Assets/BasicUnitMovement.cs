using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour {
	
	public float moveSpeed;
	public float goalRadius;
	private Vector3 goal;
	private float t;
	private bool onGoal;
	
	public void MoveOrder(Vector3 newGoal){
		goal = newGoal;
		t = 0.0f;
		onGoal = false;
	}
	
	void Start(){
		goal = transform.position;
		moveSpeed = 5.0f;
		goalRadius = 0.01f;
		t = 0.0f;
		onGoal = true;
	}
	
	void Update(){
		
		transform.position += (goal - transform.position).normalized * moveSpeed * Time.deltaTime;
		
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
