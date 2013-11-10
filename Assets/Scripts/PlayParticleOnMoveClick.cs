using UnityEngine;
using System.Collections;

public class PlayParticleOnMoveClick : MonoBehaviour {
	
	ParticleSystem pSystem;
	
	// Use this for initialization
	void Start () {
		pSystem = GameObject.FindGameObjectWithTag("ClickParticle").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void RightClicked(Vector3 clickPosition){
		pSystem.SendMessage("MoveOrder", clickPosition, SendMessageOptions.DontRequireReceiver);
	}
}
