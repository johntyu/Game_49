using UnityEngine;
using System.Collections;

public class ShootAtUnitsInRange : MonoBehaviour {
	
	public GameObject bullet;
	public float speed;
	public float fireDelay;
	public float radius;
	public LayerMask mask;
	
	private GameObject targetEnemy;
	
	void Start () {
		speed = 500.0f;
		fireDelay = 1.0f;
		radius = 5.0f;
		Invoke("Shoot", fireDelay);
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);
		
		if(enemyArray.Length > 0){
			targetEnemy = enemyArray[0].gameObject;
		}else{
			targetEnemy = null;
		}
	}
	
	void Shoot(){
		if(targetEnemy != null){
			GameObject instance = Instantiate(bullet, transform.position, bullet.transform.rotation) as GameObject;
			if(instance.rigidbody){
				instance.rigidbody.AddForce((targetEnemy.transform.position - transform.position).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
			}
		}
		
		Invoke("Shoot", fireDelay);
	}
}
