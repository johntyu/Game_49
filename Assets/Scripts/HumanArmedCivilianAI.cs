﻿using UnityEngine;
using System.Collections;

public class HumanArmedCivilianAI : MonoBehaviour {

	public float moveSpeed = 3.0f;
	public float changeDirectionPerMinute = 10.0f;

	private float changeDirectionTime = 0.0f;
	private Vector3 randomPoint;

	public float radius = 10.0f;
	public LayerMask mask;
	
	private GameObject targetEnemy = null;

	// Use this for initialization
	void Start () {
		randomPoint = transform.position + new Vector3(Random.value * 100 - 50.0f, 0.0f, Random.value * 100 - 50.0f);
	}
	
	// Update is called once per frame
	void Update () {

		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);
		
		bool enemyInRange = false;
		foreach(Collider enemy in enemyArray){
			//check if target enemy is still in range
			if(targetEnemy != null){
				if(targetEnemy == enemy.gameObject){
					enemyInRange = true;
				}
			}
		}
		
		//if enemy is out of range, stop running
		if(!enemyInRange){
			targetEnemy = null;
		}
		
		//if no target enemy, get the first one in range
		if(targetEnemy == null){
			if(enemyArray.Length > 0){
				targetEnemy = enemyArray[0].gameObject;
			}
		}
		
		if(targetEnemy != null){
			//transform.position -= (targetEnemy.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
		}else{
			transform.position += (randomPoint - transform.position).normalized * moveSpeed * Time.deltaTime;
		}

		changeDirectionTime += Time.deltaTime;
		if(changeDirectionTime >= (60.0f / changeDirectionPerMinute)){
			changeDirectionTime = 0.0f;
			randomPoint = transform.position + new Vector3(Random.value * 100 - 50.0f, 0.0f, Random.value * 100 - 50.0f);
		}
	}
}
