using UnityEngine;
using System.Collections;

public class RunAwayFromZombies : MonoBehaviour {

	public float moveSpeed = 3.0f;
	public float radius = 10.0f;
	public LayerMask mask;

	private GameObject targetEnemy = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		targetEnemy = GetComponent<ShootAtUnitsInRange>().targetEnemy;

		if(targetEnemy != null){
			transform.position -= (targetEnemy.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
		}

	}
}
