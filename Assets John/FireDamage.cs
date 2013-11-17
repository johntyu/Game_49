using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	// Use this for initialization
	
	public float createdTime;
	public float endTime = 5.0f;
	public float radius = 2.5f;
	public LayerMask mask;
	private GameObject targetEnemy;
	
	
	void Start () {
		createdTime = 0.0f;
		endTime = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		createdTime += Time.deltaTime;
		igniteFire();
	}
	
	
	public void igniteFire() {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);		
		if(enemyArray.Length > 0) {
			for(int i = 0; i < enemyArray.Length; i++) {			
				targetEnemy = enemyArray[i].gameObject;
				targetEnemy.SendMessage("firetriggerEffect", targetEnemy);	
			}
			
			if(createdTime > endTime){
				createdTime = 0.0f;
				for(int i = 0; i < enemyArray.Length; i++) {
				
					targetEnemy = enemyArray[i].gameObject;
					targetEnemy.SendMessage("EndEffect");
				
				}
				
				Object.Destroy(gameObject);
			}
		}
	}
}
