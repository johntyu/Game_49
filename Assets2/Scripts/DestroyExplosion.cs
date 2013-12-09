using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {
	
	float destroyTime = 0.5f;
	float curTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		curTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		if(curTime > destroyTime){
			Object.Destroy(gameObject);
		}
	}
}
