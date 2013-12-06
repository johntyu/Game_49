using UnityEngine;
using System.Collections;

public class WallDamagesOnAttack : MonoBehaviour {
	public GameObject wall99;
	public GameObject wall49;
	public GameObject wall01;
	
	public float breakpoint99 = 75.0f;
	public float breakpoint49 = 40.0f;
	public float breakpoint01 = 15.0f;

	public float curHealth = 20.0f;
	public float maxHealth = 20.0f;

	private GameObject prefab;
	private int currentBreakpoint;

	void BulletCollision(float damage){
		curHealth -= damage;
	}

	// Use this for initialization
	void Start () {
		float ratio = curHealth / maxHealth * 100.0f;
		if (ratio >= breakpoint99) {
			currentBreakpoint = 99;
			prefab = (GameObject) Instantiate(wall99, gameObject.transform.position, gameObject.transform.rotation);
		}
		else if (ratio >= breakpoint49) {
			currentBreakpoint = 49;
			prefab = (GameObject) Instantiate(wall49, gameObject.transform.position, gameObject.transform.rotation);
		}
		else if (ratio >= breakpoint01) {
			currentBreakpoint = 1;
			prefab = (GameObject) Instantiate(wall01, gameObject.transform.position, gameObject.transform.rotation);
		}
		else {
			Object.Destroy(gameObject);
		}
	}
	
		// Update is called once per frame
	void Update () {
		float ratio = curHealth / maxHealth * 100.0f;
		if (ratio >= breakpoint99) {
			if (currentBreakpoint == 99) {
				return;
			}
			Object.Destroy(prefab);
			prefab = (GameObject) Instantiate(wall99, gameObject.transform.position, gameObject.transform.rotation);
		}
		else if (ratio >= breakpoint49) {
			if (currentBreakpoint == 49) {
				return;
			}
			Object.Destroy(prefab);
			prefab = (GameObject) Instantiate(wall49, gameObject.transform.position, gameObject.transform.rotation);
		}
		else if (ratio >= breakpoint01) {
			if (currentBreakpoint == 1) {
				return;
			}
			Object.Destroy(prefab);
			prefab = (GameObject) Instantiate(wall01, gameObject.transform.position, gameObject.transform.rotation);
		}
		else {
			Object.Destroy(gameObject);
		}
	}
}
