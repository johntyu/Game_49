using UnityEngine;
using System.Collections;

public class CarHealthBar : MonoBehaviour {
	
	public float scale = 1.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float curHealth = transform.parent.GetComponent<CarHealth>().curHealth;
		float maxHealth = transform.parent.GetComponent<CarHealth>().maxHealth;
		Vector3 newScale = new Vector3(curHealth / maxHealth, 1.0f, 1.0f);
		gameObject.transform.localScale = newScale;
	}
}
