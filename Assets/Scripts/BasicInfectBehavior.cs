using UnityEngine;
using System.Collections;

public class BasicInfectBehavior : MonoBehaviour {

	
	public LayerMask mask;
	public float infectStartTime;
	public float infectEndTime;

	public Color colorStart;
	public Color colorEnd;
	public float duration;
	
	public float radius;
	// Use this for initialization
	void Start () {
		infectStartTime = 0.0f;
		infectEndTime = 2.0f;
		radius = 1.2f;
		colorStart = renderer.material.color;
		colorEnd = Color.green;
		duration = 2;
	}
	
	// Update is called once per frame
	void Update () {

		if(gameObject.layer == 9) {
			return;
		}

		Collider[] enemyArray =	Physics.OverlapSphere(transform.position, radius, mask);


		if(enemyArray.Length >= 3) {
			infectStartTime += Time.deltaTime;
			//float lerp = Mathf.PingPong(Time.time, duration) / duration;
			float lerp = infectEndTime - infectStartTime;
			renderer.material.color = Color.Lerp(renderer.material.color, colorEnd, lerp);

			if(infectStartTime >= infectEndTime) {
				gameObject.SendMessage("setMaskToEnemy");
			}

		}
		else if(enemyArray.Length < 3) {
			if(infectStartTime > 0) {
				infectStartTime -= Time.deltaTime;
				//float lerp = Mathf.PingPong(Time.time, duration) / duration;
				float lerp = infectStartTime;
				renderer.material.color = Color.Lerp(renderer.material.color, colorStart, lerp);
			}

			if(infectStartTime < 0) {
				infectStartTime = 0;
			}
		}
	}
}
