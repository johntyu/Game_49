using UnityEngine;
using System.Collections;

public class UnitHealthBar : MonoBehaviour {
	
	public float scale = 1.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float curHealth = transform.parent.GetComponent<UnitHealth>().curHealth;
		float maxHealth = transform.parent.GetComponent<UnitHealth>().maxHealth;
		Vector3 newScale = new Vector3(curHealth / maxHealth, 0.03f, 0.2f);
		gameObject.transform.localScale = newScale;
	}
}
