using UnityEngine;
using System.Collections;

public class TrackTargetMovement : MonoBehaviour {
	
	public float bulletSpeed;
	public GameObject theTarget;
	public Vector3 lastLoc;
	// Use this for initialization
	void Start () {
		bulletSpeed = 2;

	}
	
	// Update is called once per frame
	void Update () {
		attackTarget(theTarget);
		//If target is within collidable distance explode
	}
	
	
	//Tracks the target enemy.
	public void attackTarget(GameObject targetEnemy) {
		//Get target Location
		
		if(targetEnemy == null) {	
			Vector3 difference = lastLoc - transform.position;
	//		lastLoc.x = transform.position.x + difference.x*2;
		//	lastLoc.z =  transform.position.z + difference.z*2;
			
			lastLoc.x += (lastLoc.x - transform.position.x) * bulletSpeed * Time.deltaTime;
			lastLoc.z += (lastLoc.z - transform.position.z) * bulletSpeed * Time.deltaTime;
			
			transform.position = Vector3.Lerp(transform.position, lastLoc, bulletSpeed * Time.deltaTime);
			
			/*transform.position = Vector3.Lerp(transform.position, lastLoc, bulletSpeed * Time.deltaTime);
			if(transform.position == lastLoc) {
				Object.Destroy(gameObject);
			}*/
			
		}
		else {
			lastLoc = targetEnemy.transform.position;
			transform.position = Vector3.Lerp(transform.position, lastLoc, bulletSpeed * Time.deltaTime);
		}	
	}

	
	public void setTarget(GameObject targetEnemy) {
		theTarget = targetEnemy;
		lastLoc = targetEnemy.transform.position;
	}
	
}
