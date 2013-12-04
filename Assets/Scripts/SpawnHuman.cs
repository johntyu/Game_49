using UnityEngine;
using System.Collections;

public class SpawnHuman: MonoBehaviour {

	public GameObject unit;
	public float unitsPerMinute = 5.0f;

	private float spawnTime = 0.0f;
	private float randomNum = 0.0f;

	// Use this for initialization
	void Start () {
		randomNum = Random.value * 2.0f - 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

		spawnTime += Time.deltaTime;
		if(spawnTime >= 60.0f / (unitsPerMinute + randomNum)){
			randomNum = Random.value * 2.0f - 1.0f;
			spawnTime = 0.0f;
			GameObject instance = Instantiate(
				unit, 
				new Vector3(transform.position.x + 20.0f, transform.position.y, transform.position.z), 
				unit.transform.rotation) as GameObject;
		}
	}
}
