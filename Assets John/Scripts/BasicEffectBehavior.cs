using UnityEngine;
using System.Collections;

public class BasicEffectBehavior : MonoBehaviour {
	
	private float slowEndTime = 2.0f;
	public float slowStartTime = 0.0f;
	
	private float fireInterval = 0.1f;
	public float fireStartTime = 0.0f;
	
	public float FireDamage = 0.2f;
	public string effectType;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
		slowStartTime = 0.0f;
		effectType = "none";
		fireStartTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		continueEffect();
	}
	
	public void firetriggerEffect(GameObject triggerTarget) {
		target = triggerTarget;
		effectType = "fire";
		fireStartTime += Time.deltaTime;
	}
	
	
	public void slowtriggerEffect(GameObject triggerTarget) {
		effectType = "slow";
		target = triggerTarget;
		slowStartTime = 0.0f;
		target.SendMessage("startSlow");
	}
	
	public void EndEffect() {
		effectType = "none";
	}
	
	
	public void continueEffect() {
		if(effectType == "slow") {
			slowStartTime += Time.deltaTime;
			if(slowStartTime > slowEndTime) {
				//end effect
				target.SendMessage("endSlow");
				
			}
		}
		
		if(effectType == "fire") {
			if(fireStartTime > fireInterval) {
				//end effect
				target.SendMessage("BulletCollision", FireDamage);
				fireStartTime = 0.0f;
			}
			
		}
	}		
}
