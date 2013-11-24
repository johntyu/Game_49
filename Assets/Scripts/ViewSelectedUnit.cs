using UnityEngine;
using System.Collections;

public class ViewSelectedUnit : MonoBehaviour {

	private Texture unitMaterial;
	private Texture statsMaterial;
	private UnitManager unitManager;

	// Use this for initialization
	void Start () {
		unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
		unitMaterial = Resources.Load("blankUnit") as Texture;
		statsMaterial = Resources.Load("unitStats") as Texture;
	}
	

	// Update is called once per frame
	void Update () {

		GameObject stats = null;
		foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
			if(child.name == "SelectedUnitStats"){
				stats = child.gameObject;
			}
		}

		if (unitManager.UnitsAreSelected()) {
			unitMaterial = Resources.Load("playerUnit0") as Texture;

			stats.renderer.enabled = true;
			statsMaterial = Resources.Load("unitStats") as Texture;

		}
		else {
			unitMaterial = Resources.Load("blankUnit") as Texture;

			stats.renderer.enabled = false;
		}


		renderer.material.mainTexture = unitMaterial;
		stats.renderer.material.mainTexture = statsMaterial;
	}
}
