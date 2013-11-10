using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {
	
	float destroyTime = 3.0f;
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
