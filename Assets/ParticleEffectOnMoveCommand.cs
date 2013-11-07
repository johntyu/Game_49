using UnityEngine;
using System.Collections;

public class ParticleEffectOnMoveCommand : MonoBehaviour {
	
	public void MoveOrder(Vector3 newGoal){
		transform.position = newGoal;
		gameObject.particleSystem.Play();
	}
	
	void Start(){
		
	}
	
	void Update(){
		
	}

}
