using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	public int actualGold;
	public float goldFloat = 100.0f;
	public float goldPerMinute = 500.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		goldFloat += goldPerMinute * Time.deltaTime / 60.0f;
		actualGold = (int)goldFloat;
	}

	public void SpendGold(int amount){
		goldFloat -= amount;
	}
}
