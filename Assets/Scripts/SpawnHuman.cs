using UnityEngine;
using System.Collections;

public class SpawnHuman: MonoBehaviour {

	private CivilianManager civManager;
	public GameObject unit;
	public GameObject armedUnit;
	public float unitsPerMinute = 5.0f;

	private float spawnTime = 0.0f;
	private float randomNum = 0.0f;

	// Use this for initialization
	void Start () {
		civManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<CivilianManager>();
		randomNum = Random.value * 2.0f - 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTime += Time.deltaTime;
		if(spawnTime >= 60.0f / (unitsPerMinute + randomNum)
		   && civManager.NumCivilians() < civManager.totalCiviliansAllowed){
			randomNum = Random.value * 2.0f - 1.0f;
			spawnTime = 0.0f;
			if(Random.value < 0.1f){
				GameObject instance = Instantiate(
					armedUnit, 
					new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z), 
					unit.transform.rotation) as GameObject;
			}else{
				GameObject instance = Instantiate(
					unit, 
					new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z), 
					unit.transform.rotation) as GameObject;
			}
			civManager.AddCivilian();
		}
	}
}
