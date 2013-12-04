using UnityEngine;
using System.Collections;

public class SpawnHuman: MonoBehaviour {

	private CivilianManager civManager;
	public GameObject unit;
	public GameObject armedUnit;
	public float unitsPerMinute = 5.0f;

	private float spawnTime = 0.0f;
	private float randomNum = 0.0f;

	public float armedCivilianSpawnChancePercentIncreasePerMinute = 2.0f;
	private float armedCivilianTimer = 0.0f;

	// Use this for initialization
	void Start () {
		civManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<CivilianManager>();
		randomNum = Random.value * 2.0f - 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		armedCivilianTimer += Time.deltaTime;
		spawnTime += Time.deltaTime;
		if(spawnTime >= 60.0f / (unitsPerMinute + randomNum)
		   && civManager.NumCivilians() < civManager.totalCiviliansAllowed){
			randomNum = Random.value * 2.0f - 1.0f;
			spawnTime = 0.0f;

			Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.0f);
			float armedCivilianSpawnChance = armedCivilianTimer / 30.0f / 100.0f;

			if(Random.value < armedCivilianSpawnChance){
				GameObject instance = Instantiate(
					armedUnit, 
					spawnPosition, 
					unit.transform.rotation) as GameObject;
			}else{
				GameObject instance = Instantiate(
					unit, 
					spawnPosition, 
					unit.transform.rotation) as GameObject;
			}
			civManager.AddCivilian();
		}
	}
}
